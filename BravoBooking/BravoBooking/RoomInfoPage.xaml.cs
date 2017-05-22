using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using ADALForForms.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BravoBooking
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomInfoPage : ContentPage
    {
        string romnavn;
        DateTime date;
        DateTime time;
        public RoomInfoPage(string s)
        {
            
            InitializeComponent();
            BookNow.IsVisible = false;
            RomInfo2.Text=RoomInfoPage.TitleProperty.ToString();
            
            string skapasitet;
            int kapasitet;
            if (s[0] == 'L')
            {
                romnavn = s.Substring(10, 2);
                BookNow.IsVisible = true;
                

            }
            else
            {
                romnavn = s.Substring(15, 2);

            }
            skapasitet = s.Substring(s.Length - 2, 2);
            kapasitet = ((int)skapasitet[0] * 10) + (int)skapasitet[1];
            RomInfo.Text = "Rom: " + romnavn;
            RomInfo2.Text = "Kapasitet: " + skapasitet;
            //string roomName = ;
            //RomInfo.Text = "Du har valgt rom:";
        }
        private async void BookNow_OnClicked(Object sender, EventArgs e)
        {
            var client = new HttpClient();

            time =Convert.ToDateTime(MainTimePicker.Time);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var meData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/users?$filter=startswith(displayName,"+romnavn+")");
            var data = JsonConvert.DeserializeObject<RoomModel>(meData);
            var users = from user in data.value
                        select user;
            List<RoomModel.value2> filter = users.ToList<RoomModel.value2>();
            string id = filter[0].Id;

            var romData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/users/" +Id + "/events?$select=subject,start,end");
            //var romData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/me/events?$select=subject,start,end");
            var dat = JsonConvert.DeserializeObject<CalendarModel>(romData);
            var events = from Event in dat.value
                         select Event;
            CalendarModel.value2[] b = events.ToArray();
            DateTime now = date.Date + time.TimeOfDay;
            DateTime end = now.AddHours(1);
            bool ledig = true;
            for (int i = 0; i < b.Length; i++)
            {
                DateTime start = Convert.ToDateTime(b[i].Start.DateTime);
                if ((start < end)&&(start>now))
                {
                    ledig = false;
                }
            }

            if (ledig)
            {
                
                SendModel.value2 meeting = new SendModel.value2("Meeting at " + filter[0].DisplayName, now.ToString("yyyy-MM-ddTHH:mm:ss.fff"), end.ToString("yyyy-MM-ddTHH:mm:ss.fff"),filter[0].Mail, filter[0].DisplayName);
                
                string json = JsonConvert.SerializeObject(meeting, Formatting.Indented);

                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);

                    var httpResponse = await httpClient.PostAsync("https://graph.microsoft.com/v1.0/me/events", httpContent);
                    if (httpResponse.Content != null)
                    {
                        var send = await httpResponse.Content.ReadAsStringAsync();
                    }
                }
                Resultat.Text = "Rommet er booket.";
            }
            else
            {
                Resultat.Text = "Rommet er ikke ledig den neste timen.";
            }

        }
        private void DatePicker_OnDateSelected(Object sender, DateChangedEventArgs e)
         {
            date = e.NewDate;
         }
        //private void TimePicker_OnTimeSelected(Object sender, DateChangedEventArgs e)
        //{
        //    time = e.NewDate;
        //}


        //metode for kalender
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using ADALForForms.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace BravoBooking
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomPage : ContentPage
    {

        public RoomPage()
        {
            InitializeComponent();
            Appearing += RoomPageAppearing;
        }

        private async void RoomPageAppearing(object sender, EventArgs e)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var meData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/users?$filter=startswith(displayName,'M')");
            var data = JsonConvert.DeserializeObject<RoomModel>(meData);
            var users = from user in data.value
                        select user;


            List<RoomModel.value2> filter = users.ToList<RoomModel.value2>();

            for (int i = 0; i < filter.Count - 1; i++)
            {
                char c = filter[i].DisplayName[filter[i].DisplayName.Length - 1];
                if (!(Char.IsNumber(c)))
                {
                    //a[count] = filter[i];
                    filter.RemoveAt(i);
                    i--;

                }
            }
            RoomModel.value2[] a = filter.ToArray();


            //string[] navn = new string[a.Length];
            List<String> elementer = new List<string>();
            
            string[] id = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                DateTime now = DateTime.Now;
                bool free = true;
                var romData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/users/" + a[i].Id + "/events?$select=subject,start,end");
                var dat = JsonConvert.DeserializeObject<CalendarModel>(romData);
                var events = from Event in dat.value
                             select Event;
                CalendarModel.value2[] b = events.ToArray();

                for (int j = 0; j < b.Length; j++)
                {

                    DateTime starten = Convert.ToDateTime(b[j].Start.DateTime);
                    DateTime slutten = Convert.ToDateTime(b[j].End.DateTime);
                    if (starten < now && slutten > now)
                    {
                        free = false;
                        break;
                    }
                }
                elementer.Add(a[i].DisplayName);
               
                
                //id[i] = a[i].Id;

                if (free)
                    elementer[i]="Ledig nå: "+elementer[i];
                else
                    elementer[i] = "Ikke ledig nå: " + elementer[i];
            }
            this.RoomList.ItemsSource = elementer;
           
        }
        public void selected(RoomModel.value2[] a)
        {
            string s = (string)RoomList.SelectedItem;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].DisplayName == s)
                {
                    string id = a[i].Id;
                }
            }
        }

        private async void RoomList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selection = e.SelectedItem as string;
                //DisplayAlert("Du har valgt et rom", selection, "OK");
                var roomInfo = new RoomInfoPage() { Title = "Bravo Booking" };
                //roomInfo(new RoomInfoPage() { Title = "Book NÅ" });
                await Navigation.PushAsync(roomInfo);

            }
        }
    }
}

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using BravoBooking.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace BravoBooking
{
	public partial class MePage : ContentPage
	{
        public MePage()
        {
            InitializeComponent();
            this.Appearing += MePageAppearing;
            
            NumberOfPersonsPicker.Items.Add("4 personer");
            NumberOfPersonsPicker.Items.Add("6 personer");
            NumberOfPersonsPicker.Items.Add("10 personer");
            
            StartTimePicker.Items.Add("Akkurat nå");
            StartTimePicker.Items.Add("Neste halvtime");
            StartTimePicker.Items.Add("Neste hele time");
           
            DurationPicker.Items.Add("1 time");
            DurationPicker.Items.Add("2 timer");
            DurationPicker.Items.Add("3 timer");

            var button = new Button { Text = "Book NÅ!", TextColor = Color.FromHex("#77d065"), FontSize = 20};
            
        }

        private async void MePageAppearing(object sender, EventArgs e)
        {
            var client = new HttpClient();
            
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var meData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/me");
            var userData = JsonConvert.DeserializeObject<UserModel>(meData);
            //this.DisplayName.Text = userData.DisplayName;
            //this.Mail.Text = userData.Mail;
            //this.Country.Text = userData.Country;
        }


        private void AntallPersoner_OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            var name = NumberOfPersonsPicker.Items[NumberOfPersonsPicker.SelectedIndex];

            //DisplayAlert(name, "Selected value", "OK");
        }

        private void WhenPicker_OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            var name = StartTimePicker.Items[StartTimePicker.SelectedIndex];

            //DisplayAlert(name, "Selected value", "OK");
        }

        private void TidPicker_OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            var name = DurationPicker.Items[DurationPicker.SelectedIndex];

            //DisplayAlert(name, "Selected value", "OK");
        }

        private async void BookNow_OnClicked(Object sender, EventArgs e)
        {

           
            string text = MainEntry.Text;
            string antalls=NumberOfPersonsPicker.Items[Math.Max(0,NumberOfPersonsPicker.SelectedIndex)];
            int startint = Math.Max(0,StartTimePicker.SelectedIndex);
            string varig = DurationPicker.Items[Math.Max(0,DurationPicker.SelectedIndex)];
            DateTime now = DateTime.Now;


            int antall = int.Parse(antalls[0].ToString());

            if (startint == 1)
            {
                startint = 30;
            }
            else if (startint == 2)
            {
                startint = 60;
            }
            
            DateTime date=now.AddMinutes((double)startint);

            DateTime end = date.AddHours(Double.Parse(varig[0].ToString()));;
            

            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var meData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/users?$filter=startswith(displayName,'M')");
            var data = JsonConvert.DeserializeObject<RomModel>(meData);
            var users = from user in data.value
                        select user;
            RomModel.value2[] a = users.ToArray();
            bool done = false;

            for(int i=0; i<1;i++)
            {
                //<TODO: Kode å filtrere etter antall personer>
                bool free=true;
                //var romData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/users/"+a[i].Id+ "/events");
                var romData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/me/events");
                var dat = JsonConvert.DeserializeObject<CalendarModel>(romData);
                var events = from Event in dat.value
                             select Event;
                CalendarModel.value2[] b = events.ToArray();


                for(int j = 0; j < b.Length; j++)
                {
                    DateTime starten = Convert.ToDateTime(b[j].Start.DateTime);
                    DateTime slutten = Convert.ToDateTime(b[j].End.DateTime);
                    if ((starten > date && starten < end)||(slutten>date && slutten<end))
                    {
                        free = false;
                        break;
                    }
                }
                if (free)
                {
                    //<TODO: Sette Opp møte mellom (now) og (end) på møterom b[i]>
                    done = true;
                    break;
                }

               
                

            }
            if (done)
            {
                MainLabel.Text = "Rommet er booket";
            }
            else
            {
                MainLabel.Text = "Det er desverre ingen ledige rom som passer dine kriterier.";
            }            
        }


    }
}


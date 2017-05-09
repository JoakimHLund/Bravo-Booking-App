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
	public partial class BookNowPage : ContentPage
	{
        public BookNowPage()
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
            
        }


        private void AntallPersoner_OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            var name = NumberOfPersonsPicker.Items[NumberOfPersonsPicker.SelectedIndex];
            
        }

        private void WhenPicker_OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            var name = StartTimePicker.Items[StartTimePicker.SelectedIndex];
            
        }

        private void TidPicker_OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            var name = DurationPicker.Items[DurationPicker.SelectedIndex];
            
        }

        private async void BookNow_OnClicked(Object sender, EventArgs e)
        {
            string text = MainEntry.Text;
            int antall=NumberOfPersonsPicker.SelectedIndex;
            int start = StartTimePicker.SelectedIndex;
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var meData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/users?$filter=startswith(displayName,'M')");
            var data = JsonConvert.DeserializeObject<RoomModel>(meData);
            var users = from user in data.value
                        select user;
            RoomModel.value2[] a = users.ToArray();
            for(int i=0; i<a.Length;i++)
            {
                var romData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/users/"+a[i].Id+"/");
                var dat = JsonConvert.DeserializeObject<RoomModel>(romData);
                string s = dat.ToString();
                MainLabel.Text = "Rommet er booket" + s;

            }
            
        }

        


    }
}


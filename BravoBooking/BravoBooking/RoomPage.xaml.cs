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

            //var rom = new ListViewItem { BackColor = "Red" };

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
            RoomModel.value2[] a = users.ToArray();
            string[] navn = new string[a.Length];
            string[] id = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                navn[i] = a[i].DisplayName;
                id[i] = a[i].Id;
            }
            this.RoomList.ItemsSource = navn;
            


        }
        public void selected(RoomModel.value2[] a)
        {
            string s=(string)RoomList.SelectedItem;
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i].DisplayName == s)
                {
                    string id = a[i].Id;
                }
                
            }
            
        }

        /*private async void RoomList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*if(e.SelectedItem != null)
            {
                //var selection = e.SelectedItem as RomModel.value2;
                //var name = RoomList[Items]
                var romInfo = new ContentPage() { Title = "Bravo Booking" };
                    await Navigation.PushAsync(romInfo);
                //DisplayAlert("Du har valgt et rom", selection.DisplayName, "OK");
                    
            }
            //var romInfo = new ContentPage() { Title = "Bravo Booking" };
            //await Navigation.PushAsync(romInfo);*/
        

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

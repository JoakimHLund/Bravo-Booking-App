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
    public partial class Room : ContentPage
    {

        public Room()
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
            var data = JsonConvert.DeserializeObject<RomModel>(meData);
            var users = from user in data.value
                        select user;
            RomModel.value2[] a = users.ToArray();
            string[] navn = new string[a.Length];
            string[] id = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                navn[i] = a[i].DisplayName;
                id[i] = a[i].Id;
            }
           // this.RoomList.ItemSource = navn;


        }

    }
}

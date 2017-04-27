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
	public partial class RomTid : ContentPage
	{
		public RomTid ()
		{
			InitializeComponent ();
            Appearing += RomTidAppearing;
		}

        private async void RomTidAppearing(object sender, EventArgs e)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var meData = await client.GetStringAsync("https://graph.microsoft.com/1.0/users");
            var data = JsonConvert.DeserializeObject<RomModel>(meData);
            var users = from user in data.value
                        select user.DisplayName;
            this.FileList.ItemsSource = users.ToList();
        }

    }
}


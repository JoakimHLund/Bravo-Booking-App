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
	public partial class FilesPage : ContentPage
	{
		public FilesPage ()
		{
			InitializeComponent ();
            Appearing += FilesPageAppearing;
		}

        private async void FilesPageAppearing(object sender, EventArgs e)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var meData2 = await client.GetStringAsync("https://graph.microsoft.com/v1.0/me");
            var meData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/users/7da0ba65-dfd3-4f4a-a0ba-c4c9238b5b1e");
            var data = JsonConvert.DeserializeObject<RomModel>(meData);
            var users = from user in data.value
                        select user.DisplayName;
            this.FileList.ItemsSource = users.ToList();
        }
    }
}


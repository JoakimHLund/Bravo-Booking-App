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
            //var meData2 = await client.GetStringAsync("https://graph.windows.net/strockisdev.onmicrosoft.com/oauth2PermissionGrants");
            //System.Diagnostics.Debug.WriteLine(meData2);
            var meData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/users/");
            //meData.Content
            //var data = JsonConvert.DeserializeObject<RomModel>(meData.Content.ToString);
            //var users = from user in data.value
            //            select user.GivenName;
            //this.FileList.ItemsSource = users.ToList();
        }
    }
}


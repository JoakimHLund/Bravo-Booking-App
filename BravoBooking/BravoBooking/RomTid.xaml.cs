using System;
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

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            /*var meData = await client.GetStringAsync("https://graph.microsoft.com/beta/me/files");
            var data = JsonConvert.DeserializeObject<FilesModel>(meData);
            var files = from file in data.Value
                where file.Type.ToLower() == "file"
                select file.Name;
            this.FileList.ItemsSource = files.ToList();*/

            /*App.AuthenticationResult = await DependencyService.Get<IAuthenticator>()
                .Authenticate(authority, graphResourceUri, clientId, returnUri);
            var userName = App.AuthenticationResult.UserInfo.GivenName + " "
                + App.AuthenticationResult.UserInfo.FamilyName;
            await DisplayAlert("Token", userName, "Ok", "Cancel");*/
            var tabbedPage = new TabbedPage() { Title = "Bravo Booking" };
            tabbedPage.Children.Add(new Calendar() { Title = "Kalender" });
            tabbedPage.Children.Add(new Room() { Title = "Rom" });
            await Navigation.PushAsync(tabbedPage);
        }

    }
}


    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Xamarin.Forms;

    namespace BravoBooking
    {
        public partial class HomePage : ContentPage
        {
            public static string clientId = "11fd1b53-7392-412c-b3cc-ba155da9773b";
            public static string[] Scopes = { "https://graph.microsoft.com/Calendars.Read", "https://graph.microsoft.com/Contacts.Read", "https://graph.microsoft.com/User.Read", "User.ReadBasic.All" };
            public static string authority = "https://login.microsoftonline.com/common";
            public static string returnUri = "http://bravo-booking";
            private const string graphResourceUri = "https://graph.microsoft.com";
            public static string graphApiVersion = "2013-11-08";

            public HomePage()
            {
                InitializeComponent();
            }

            private async void Button_OnClicked(object sender, EventArgs e)
            {
                
                App.AuthenticationResult = await DependencyService.Get<IAuthenticator>()
                    .Authenticate(authority, graphResourceUri, clientId, returnUri);
                var userName = App.AuthenticationResult.UserInfo.GivenName + " "
                    + App.AuthenticationResult.UserInfo.FamilyName;
                await DisplayAlert("logged inn: ", userName, "Ok", "Cancel");
                var tabbedPage = new TabbedPage() { Title = "Bravo Booking" };
                tabbedPage.Children.Add(new MePage() { Title = "About Me" });
                tabbedPage.Children.Add(new FilesPage() { Title = "My Files" });
                await Navigation.PushAsync(tabbedPage);


            //Oaut2 https://docs.microsoft.com/nb-no/azure/active-directory/develop/active-directory-protocols-oauth-code
            /*var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                "https://login.windows.net/5c931cf5-d6f4-4b91-b8ae-efab06017fdf/oauth2/authorize?client_id=11fd1b53-7392-412c-b3cc-ba155da9773b&response_type=code&redirect_uri=http://bravo-booking&response_mode=query&resource=https%3A%2F%2Fservice.contoso.com%2F&state=12345?&prompt=consent");
            HttpResponseMessage response = await client.SendAsync(request);
            System.Diagnostics.Debug.WriteLine("Writeline:" + response.Content.ToString());
            System.Diagnostics.Debug.WriteLine("Writeline2:" + response.ToString());
            //response.
            var client2 = new HttpClient();*/
        }
        /*private async void Button_OnClicked(object sender, EventArgs e)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            HttpResponseMessage hrm = client.SendAsync(https://login.windows.net/5c931cf5-d6f4-4b91-b8ae-efab06017fdf/oauth2/authorize);
        }*/
        /*private async void Button_OnClicked2(object sender, EventArgs e)
        {
        //https://login.windows.net/common/oauth2/logout?post_logout_r‌​edirect_uri=<returnU‌​rl>
        App.AuthenticationResult = await DependencyService.Get<IAuthenticator>()
            .Authenticate(null, null, null, null); //Feil

    }*/
    }
    }
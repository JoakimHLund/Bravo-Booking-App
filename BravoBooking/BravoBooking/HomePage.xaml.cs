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
            //public static string clientId = "4cd1357a-4493-488a-9bba-ebb82c15df08";
            public static string[] Scopes = { "https://graph.microsoft.com/Calendars.Read", "https://graph.microsoft.com/Contacts.Read", "https://graph.microsoft.com/User.Read", "https://graph.microsoft.com/User.ReadBasic.All" };
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
            }
        }
    }
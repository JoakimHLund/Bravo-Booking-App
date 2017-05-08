using BravoBooking.Model;
using BravoBooking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BravoBooking
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profil : ContentPage
    {
        public Profil()
        {
            InitializeComponent();
            Appearing += ProfilAppearing;

            var tapImage = new TapGestureRecognizer();
            //Binding events  
            tapImage.Tapped += tapImage_Tapped;
            //Associating tap events to the image buttons  
            img.GestureRecognizers.Add(tapImage);
            img1.GestureRecognizers.Add(tapImage);

            string userName = App.AuthenticationResult.UserInfo.GivenName + " " + App.AuthenticationResult.UserInfo.FamilyName;
            MinProfil.Text = "Du er logget inn som: " + userName;

            //Liste som henter bookinger gjort av innlogget person
            /*var ListView = new ListView();
            listView.ItemsSource = BookingModel.
            Content = listView;*/

        }
        
        private async void tapImage_Tapped(object sender, EventArgs e)
        {
            // handle the tap  
            //DisplayAlert("Alert", "Innstillinger", "OK");
            var settingsPage = new ContentPage() { Title = "Innstillinger" };
            await Navigation.PushModalAsync(settingsPage);
            //await Navigation.PushModalAsync(new Settings());
        }


        /*private async void ProfilAppearing(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var userName = App.AuthenticationResult.UserInfo.GivenName + " "
                + App.AuthenticationResult.UserInfo.FamilyName;
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            //var meData = await client.GetStringAsync("https://graph.microsoft.com/beta/me");
            //var userData = JsonConvert.DeserializeObject<UserModel>(meData);
            //this.DisplayName.Text = userData.DisplayName;
            
        }*/
    }
}

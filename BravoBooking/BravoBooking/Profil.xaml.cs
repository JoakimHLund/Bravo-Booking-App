using ADALForForms.Model;
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
            img2.GestureRecognizers.Add(tapImage);

            string userName = App.AuthenticationResult.UserInfo.GivenName + " " + App.AuthenticationResult.UserInfo.FamilyName;
            MinProfil.Text = "Du er logget inn som: " + userName;
        }
        
        private async void tapImage_Tapped(object sender, EventArgs e)
        {
            // handle the tap  
            DisplayAlert("Alert", "Innstillinger", "OK");
        }

        private async void ProfilAppearing(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var userName = App.AuthenticationResult.UserInfo.GivenName + " "
                + App.AuthenticationResult.UserInfo.FamilyName;
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            //var meData = await client.GetStringAsync("https://graph.microsoft.com/beta/me");
            //var userData = JsonConvert.DeserializeObject<UserModel>(meData);
            //this.DisplayName.Text = userData.DisplayName;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var romData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/me/events");
            var dat = JsonConvert.DeserializeObject<CalendarModel>(romData);
            var events = from Event in dat.value
                         select Event;
            CalendarModel.value2[] b = events.ToArray();
            string[] s=new string[b.Length];
            int j = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if ('M' == b[i].Attendees.name[0])
                {
                    s[j] = b[i].subject + "     " + b[i].Start.DateTime;
                    j++;
                }

            }
            if (j==0)
            {
                string[] ingen = { "Du har ingen kommende møter" };
                this.RoomList.ItemsSource = ingen;
            }
            else
            {
                this.RoomList.ItemsSource = s;
            }
            


        }
    }
}

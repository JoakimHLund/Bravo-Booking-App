﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using ADALForForms.Model;
using Microsoft.OData.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace BravoBooking
{
	public partial class MePage : ContentPage
	{
        public MePage()
        {
            InitializeComponent();
            this.Appearing += MePageAppearing;
            
            NumberOfPersonsPicker.Items.Add("4 personer");
            NumberOfPersonsPicker.Items.Add("6 personer");
            NumberOfPersonsPicker.Items.Add("10 personer");
            
            StartTimePicker.Items.Add("Akkurat nå");
            StartTimePicker.Items.Add("Neste halvtime");
            StartTimePicker.Items.Add("Neste hele time");
           
            DurationPicker.Items.Add("1 time");
            DurationPicker.Items.Add("2 timer");
            DurationPicker.Items.Add("3 timer");

            var button = new Button { Text = "Book NÅ!", TextColor = Color.FromHex("#77d065"), FontSize = 20};
            
        }

        private async void MePageAppearing(object sender, EventArgs e)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var meData = await client.GetStringAsync("https://graph.microsoft.com/v1.0/me");
            var userData = JsonConvert.DeserializeObject<UserModel>(meData);
            //this.DisplayName.Text = userData.DisplayName;
            //this.Mail.Text = userData.Mail;
            //this.Country.Text = userData.Country;
        }


        private void AntallPersoner_OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            var name = NumberOfPersonsPicker.Items[NumberOfPersonsPicker.SelectedIndex];

            //DisplayAlert(name, "Selected value", "OK");
        }

        private void WhenPicker_OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            var name = StartTimePicker.Items[StartTimePicker.SelectedIndex];

            //DisplayAlert(name, "Selected value", "OK");
        }

        private void TidPicker_OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            var name = DurationPicker.Items[DurationPicker.SelectedIndex];

            //DisplayAlert(name, "Selected value", "OK");
        }

        private void BookNow_OnClicked(Object sender, EventArgs e)
        {
            string text = MainEntry.Text;

            MainLabel.Text = "Rommet er booket" + text;
        }


    }
}


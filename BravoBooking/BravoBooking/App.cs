﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using ADALForForms;

namespace BravoBooking
{
    public class App : Application
    {
        
        internal static AuthenticationResult AuthenticationResult { get; set; }
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

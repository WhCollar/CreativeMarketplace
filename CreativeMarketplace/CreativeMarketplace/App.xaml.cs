﻿using CreativeMarketplace.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreativeMarketplace
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
          
            MainPage = new NavigationPage(new LogInPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

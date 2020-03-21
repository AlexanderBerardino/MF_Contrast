﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MFContrast.Services;
using MFContrast.Views;

namespace MFContrast
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();


            // MainPage = new ItemsPage();


            var tabs = new TabbedPage();

            var page = new ItemsPage();
            tabs.Children.Add(new NavigationPage(page) { Title = "Tab title" });
            MainPage = tabs;

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

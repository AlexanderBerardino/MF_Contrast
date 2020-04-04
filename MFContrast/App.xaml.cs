using System;
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
            // DependencyService.Register<GenerateHoldingsList>();
            // DependencyService.Register<GenerateWebHoldingsList>();


            // tabs is the Main Page
            TabbedPage tabs = new TabbedPage();

            // Children pages of tabs
            ItemsPage page = new ItemsPage();
            ComparePage comparePage = new ComparePage();
            AboutPage aboutPage = new AboutPage();
            
            tabs.Children.Add(new NavigationPage(page) { Title = "View Funds" });
            tabs.Children.Add(new NavigationPage(comparePage) { Title = "MFContrast" });
            tabs.Children.Add(new NavigationPage(aboutPage) { Title = "About" });

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

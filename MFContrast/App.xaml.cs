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

            var tabs = new TabbedPage();
            var page = new ItemsPage();
            var comparePage = new ComparePage();
            var aboutPage = new AboutPage();
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

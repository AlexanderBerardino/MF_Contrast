using Xamarin.Forms;
using MFContrast.Services;
using MFContrast.Views;
using System;

namespace MFContrast
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            // DependencyService.Register<AWSDownloader>();


            // tabs is the Main Page
            TabbedPage tabs = new TabbedPage();

            // Children pages of tabs
            ItemsPage itemsPage = new ItemsPage();
            ComparePage comparePage = new ComparePage();
            AboutPage aboutPage = new AboutPage();

            // Order of the tabbed pages
            tabs.Children.Add(new NavigationPage(comparePage) { Title = "Compare Funds" });
            tabs.Children.Add(new NavigationPage(itemsPage) { Title = "View Fund Holdings" });
            tabs.Children.Add(new NavigationPage(aboutPage) { Title = "About" });

            MainPage = tabs;

        }

        protected override void OnStart() // if using AWSDownloader, make this method async
        {
            // DependencyService.Register<AWSDownloader>();
            // var downloaded = await AWSDownloader.S3DirectoryDownloadAsync();
            // Console.WriteLine(downloaded);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

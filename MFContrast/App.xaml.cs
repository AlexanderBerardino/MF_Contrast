using Xamarin.Forms;
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
            ItemsPage itemsPage = new ItemsPage();
            ComparePage comparePage = new ComparePage();
            AboutPage aboutPage = new AboutPage();

            // Order of the tabbed pages
            tabs.Children.Add(new NavigationPage(comparePage) { Title = "Compare Funds" });
            tabs.Children.Add(new NavigationPage(itemsPage) { Title = "View Fund Holdings" });
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

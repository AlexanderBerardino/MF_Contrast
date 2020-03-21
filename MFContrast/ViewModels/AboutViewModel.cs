
using Xamarin.Forms;

namespace MFContrast.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ListView AboutListView;
        public StackLayout Layout;
        public AboutViewModel()
        {
            Title = "About";
            AboutListView = InitializeAboutListView();
            Layout = new StackLayout();
            Layout.Children.Add(AboutListView);

        }

        public ListView InitializeAboutListView()
        {
            ListView listView = new ListView();
            listView.ItemsSource = new string[]
            {
                "What is each page for?",
                "How do I use the contrast functionality",
                "Where does this data come from?",
                "How often are the funds updated?",
                "Are all assets in each fund viewable and being compared"
            };
            return listView;
        }

    }
}
using System;
using System.ComponentModel;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        private ListView _AboutListView = new ListView();

        public AboutViewModel viewModel;

        public AboutPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AboutViewModel();
            Content = viewModel.Layout;
        }

        // Example of a possible Alert event handler 
        public void Help_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Good Help", "You clicked on help, best of luck", "Bad Help", "You clicked on help!? Too bad!");
        }


    }
}
using System;
using System.ComponentModel;
using MFContrast.Models;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutViewModel ViewModel { get; set; }

        public AboutPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new AboutViewModel();
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            FAQ tappedFAQ = args.Item as FAQ;
            await Navigation.PushAsync(new AboutDetailPage(new AboutDetailViewModel(tappedFAQ)));
        }

        // Example of a possible Alert event handler 
        public void Help_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Good Help", "You clicked on help, best of luck", "Bad Help", "You clicked on help!? Too bad!");
        }
    }
}
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MFContrast.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        // Example of a possible Alert event handler 
        public void Help_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Good Help", "You clicked on help, best of luck", "Bad Help", "You clicked on help!? Too bad!");
        }
    }
}
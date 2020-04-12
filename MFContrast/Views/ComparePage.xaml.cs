using System;
using System.ComponentModel;
using MFContrast.Models;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views

{
    [DesignTimeVisible(false)]
    public partial class ComparePage : ContentPage
    {
        public CompareViewModel ViewModel { get; set; }

        // Directions for UI usage
        public static string CompareTitleLabelText => compareTitleLabelText;
        private const string compareTitleLabelText = "Select Two Different Funds and Click Compare to View Results!";

        public ComparePage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new CompareViewModel();
            CompareTitleLabel.Text = CompareTitleLabelText;
        }

        public ComparePage(CompareViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel = viewModel;
        }

        // Event Handler for Compare Button
        public async void ContrastClicked(object sender, EventArgs eventArgs)
        {
            Picker picker1 = FindByName("Picker1") as Picker;
            Picker picker2 = FindByName("Picker2") as Picker;

            if (picker1.SelectedItem == null || picker2.SelectedItem == null || picker1.SelectedItem == picker2.SelectedItem)
            {
                await DisplayAlert("Alert", "Must Compare Two Different Mutual Funds", "Ok");
            }
            else
            {
                MutualFund f1 = picker1.SelectedItem as MutualFund;
                MutualFund f2 = picker2.SelectedItem as MutualFund;

                try
                {
                    await Navigation.PushAsync(new PostCompareCarouselPage(new PostCompareOverlapViewModelV2(f1, f2)));
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("Exception thrown:" + ex);
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.Funds.Count == 0)
                ViewModel.LoadItemsCommand.Execute(null);
        }
    }
}

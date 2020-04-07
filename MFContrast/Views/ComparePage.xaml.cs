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
        public CompareViewModel viewModel;

        public ComparePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CompareViewModel();
        }

        public ComparePage(CompareViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

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

            if (viewModel.Funds.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}

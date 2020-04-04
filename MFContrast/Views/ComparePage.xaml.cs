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
            viewModel = new CompareViewModel();
            BindingContext = viewModel;
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

            MutualFund f1 = picker1.SelectedItem as MutualFund;
            MutualFund f2 = picker2.SelectedItem as MutualFund;

            // Input must be set to instance
            MutualFund F1 = new MutualFund(f1.Ticker) {
                AssetList = f1.AssetList,
                FundName = f1.FundName,
                Id = f1.Id,
                Ticker = f1.Ticker
            };
            MutualFund F2 = new MutualFund(f2.Ticker) {
                AssetList = f2.AssetList,
                FundName = f2.FundName,
                Id = f2.Id,
                Ticker = f2.Ticker
            };

            try
            {
                await Navigation.PushAsync(new PostCompareCarouselPage(new PostCompareOverlapViewModel(F1, F2)));
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Exception thrown:" + ex);
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

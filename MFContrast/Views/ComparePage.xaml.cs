using System;
using System.Collections.Generic;
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
            // Bind f1 and f2 to picker selections
            // MutualFund f1 = await viewModel.MutualFundDataStore.GetItemAsync("0");
            // MutualFund f2 = await viewModel.MutualFundDataStore.GetItemAsync("1");
            MutualFund f3 = new MutualFund("vfiax")
            {
                Id = "0",
                FundName = "Vanguard",
                // Ticker = "vfiax",

            };
            MutualFund f4 = new MutualFund("fcntx")
            {
                Id = "1",
                FundName = "Fidelity",
                // Ticker = "fcntx"
            };

            try
            {
                // PostCompareViewModel postCompareViewModel = new PostCompareViewModel(f3, f4);
                // PostComparePage postComparePage = new PostComparePage(postCompareViewModel);
                PostCompareOverlapViewModel postCompareOverlapViewModel = new PostCompareOverlapViewModel(f3, f4);
                PostCompareCarouselPage postCompareCarouselPage = new PostCompareCarouselPage(postCompareOverlapViewModel);

                // await Navigation.PushAsync(postComparePage);
                await Navigation.PushAsync(postCompareCarouselPage);

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

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
            // Eventually will use two picker choices or agruments
            MutualFund f1 = await viewModel.MutualFundDataStore.GetItemAsync("0");
            MutualFund f2 = await viewModel.MutualFundDataStore.GetItemAsync("1");

            try
            {
                PostCompareViewModel postCompareViewModel = new PostCompareViewModel(f1, f2);
                PostComparePage postComparePage = new PostComparePage(postCompareViewModel);
                await Navigation.PushAsync(postComparePage);

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

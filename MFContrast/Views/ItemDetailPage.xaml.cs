using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MFContrast.Models;
using MFContrast.ViewModels;
using MFContrast.Services;
using MFContrast.Models.AlternativeMutualFundModels;

namespace MFContrast.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            BindingContext = this.viewModel;

            Content = viewModel.Layout;

            

        }

        public ItemDetailPage()
        {
            AlternativeMutualFundWhole holderFund = new AlternativeMutualFundWhole { FundName = "Holder Fund", Id = "0" };
            InitializeComponent();
            viewModel = new ItemDetailViewModel(holderFund);
            BindingContext = viewModel;

        }



    }
}
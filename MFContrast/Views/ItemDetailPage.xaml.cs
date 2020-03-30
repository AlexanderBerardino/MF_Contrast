using System.ComponentModel;
using Xamarin.Forms;

using MFContrast.Models;
using MFContrast.ViewModels;

namespace MFContrast.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailViewModel viewModel { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            BindingContext = this.viewModel;

            Content = viewModel.Layout;
        }

        public ItemDetailPage()
        {
            MutualFund holderFund = new MutualFund("") { FundName = "Holder Fund", Id = "0" };
       
            InitializeComponent();
            viewModel = new ItemDetailViewModel(holderFund);
            BindingContext = viewModel;

        }



    }
}
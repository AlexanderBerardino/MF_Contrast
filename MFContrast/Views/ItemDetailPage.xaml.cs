using System.ComponentModel;
using Xamarin.Forms;

using MFContrast.Models;
using MFContrast.ViewModels;

namespace MFContrast.Views
{
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailViewModel viewModel { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            Content = viewModel.Layout;
        }

        public ItemDetailPage()
        {
            MutualFund holderFund = new MutualFund("MockFund") { FundName = "Holder Fund", Id = "0" };
       
            InitializeComponent();
            BindingContext = viewModel = new ItemDetailViewModel(holderFund);
        }
    }
}
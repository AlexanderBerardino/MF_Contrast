using System;
using System.ComponentModel;
using Xamarin.Forms;
using MFContrast.Models;
using MFContrast.ViewModels;

namespace MFContrast.Views
{
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        readonly ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            MutualFund fund = args.SelectedItem as MutualFund;
            if (fund == null)
                return;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(fund)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            MutualFund tappedFund = args.Item as MutualFund;
            await Navigation.PushAsync((new ItemDetailPage(new ItemDetailViewModel(tappedFund))));

        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Funds.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
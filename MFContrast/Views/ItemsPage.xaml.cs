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
        private readonly ItemsViewModel ViewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ItemsViewModel();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (sender is null || args is null)
            {
                throw new ArgumentNullException(nameof(sender), nameof(args));
            }
            MutualFund fund = args.SelectedItem as MutualFund;
            if (fund is null)
            {
                return;
            }
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(fund)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            MutualFund fund = args.Item as MutualFund;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(fund)));
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel.Funds.Count == 0)
            {
                ViewModel.LoadItemsCommand.Execute(null);
            }
        }
    }
}
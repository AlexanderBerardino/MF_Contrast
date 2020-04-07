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
        public ItemsViewModel viewModel { get; set; }

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (sender is null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
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

        async void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            MutualFund fund = args.Item as MutualFund;
            if (fund == null) { return; }
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(fund)));

            //  Manually deselect item.

            ItemsListView.SelectedItem = null;
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
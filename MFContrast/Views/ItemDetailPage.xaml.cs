﻿using System.ComponentModel;
using Xamarin.Forms;
using MFContrast.Models;
using MFContrast.ViewModels;

namespace MFContrast.Views
{
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        private readonly ItemDetailViewModel ViewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel = viewModel;

            // Adds Labels to Grid
            for (int i = 0; i < ViewModel.HoldingsList.Count; i++)
            {
                ItemDetailMainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Auto) });
                ItemDetailMainGrid.Children.Add(new Label
                {
                    Text = ViewModel.HoldingsList[i].Rank,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, 0, i);
                ItemDetailMainGrid.Children.Add(new Label
                {
                    Text = ViewModel.HoldingsList[i].Name,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle

                }, 1, i);
                ItemDetailMainGrid.Children.Add(new Label
                {
                    Text = ViewModel.HoldingsList[i].Percentage,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, 2, i);
            }
        }

        public ItemDetailPage()
        {
            MutualFund holderFund = new MutualFund("MockFund") { FundName = "Holder Fund", Id = "0" };
       
            InitializeComponent();
            BindingContext = ViewModel = new ItemDetailViewModel(holderFund);
        }
    }
}
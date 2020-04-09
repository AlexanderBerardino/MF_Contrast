﻿using System.Collections.Generic;
using MFContrast.Models;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareOverlapPage : ContentPage
    {
        public PostCompareOverlapViewModelSpecific ViewModel { get; set; }

        public PostCompareOverlapPage(PostCompareOverlapViewModelSpecific viewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel = viewModel;

            //for (int i = 0; i < viewModel.ListMaxRow; i++)
            //{
            //    PostCompareMainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Auto) });
            //}

            //PopulateColumnTemplate(viewModel.OverlapListSize, 0, viewModel.OverlapList);
            //PopulateColumnTemplate(viewModel.U1Size, 1, viewModel.Unique1);
            //PopulateColumnTemplate(viewModel.U2Size, 2, viewModel.Unique2);
            for (int i = 0; i < 10; i++)
            {
                PostCompareMainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Auto) });
            }

            PopulateColumnTemplate(10, 0, viewModel.OverlapList);
            PopulateColumnTemplate(10, 1, viewModel.Unique1);
            PopulateColumnTemplate(10, 2, viewModel.Unique2);

        }

        // Eventually move function up to viewmodel
        private void PopulateColumnTemplate(int endIndex, int rowNumber, List<Holding> sourceList)
        {
            for (int i = 0; i < endIndex; i++)
            {
                PostCompareMainGrid.Children.Add(new Label
                {
                    Text = string.Join(" ", sourceList[i].Symbol, ":", sourceList[i].Percentage),
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, rowNumber, i);
            }
        }

        // Eventually move function up to viewmodel
        private void PopulateColumnTemplate(int endIndex, int rowNumber, List<string> sourceList)
        {
            for (int i = 0; i < endIndex; i++)
            {
                PostCompareMainGrid.Children.Add(new Label
                {
                    Text = sourceList[i],
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, rowNumber, i);
            }
        }
    }
}

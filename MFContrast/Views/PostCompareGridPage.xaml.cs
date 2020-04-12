using System;
using System.Collections.Generic;
using MFContrast.Models;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareGridPage : ContentPage
    {
        public PostCompareOverlapGridViewModel ViewModel { get; set; }

        public PostCompareGridPage(PostCompareOverlapGridViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel = viewModel;

            for (int i = 0; i < viewModel.ListMaxRow; i++)
            {
                PostCompareGridMainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Auto) });
            }

            PopulateColumnTemplate(viewModel.OverlapListSize, 0, viewModel.OverlapList);
            PopulateColumnTemplate(viewModel.U1Size, 1, viewModel.Unique1);
            PopulateColumnTemplate(viewModel.U2Size, 2, viewModel.Unique2);

        }

        // Eventually move function up to viewmodel
        private void PopulateColumnTemplate(int endIndex, int rowNumber, List<Holding> sourceList)
        {
            for (int i = 0; i < endIndex; i++)
            {
                PostCompareGridMainGrid.Children.Add(new Label
                {
                    Text = string.Join(" ", sourceList[i].Symbol, ":", sourceList[i].Percentage),
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, rowNumber, i);
            }
        }

        // Eventually move function up to viewmodel
        private void PopulateColumnTemplate(int endIndex, int rowNumber, List<string> sourceList)
        {
            for (int i = 0; i < endIndex; i++)
            {
                PostCompareGridMainGrid.Children.Add(new Label
                {
                    Text = sourceList[i],
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, rowNumber, i);
            }
        }
    }
}

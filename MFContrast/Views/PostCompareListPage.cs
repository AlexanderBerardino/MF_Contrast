using System;
using System.Collections.Generic;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public class PostCompareListPage : ContentPage
    {
        PostCompareOverlapViewModel viewModel;
        public Grid UniqueHoldingsBody { get; set; }
        public Grid UniqueHoldingsHeader { get; set; }
        public StackLayout UniqueHoldingsLayout { get; set; }
        public string UpperTicker1 => viewModel.Fund1.Ticker.ToUpper();
        public string UpperTicker2 => viewModel.Fund2.Ticker.ToUpper();


        public PostCompareListPage(PostCompareOverlapViewModel viewModel)
        {
            BindingContext = this.viewModel = viewModel;
            UniqueHoldingsHeader = SetHeaderGridTemplate("Overlap", string.Join(separator: " ", UpperTicker1 + "Unique"), string.Join(separator: " ", UpperTicker2 + "Unique"));
            UniqueHoldingsBody = SetUniqueHoldingsBody();
            PopulateGrid();
            UniqueHoldingsLayout = new StackLayout {
                Orientation = StackOrientation.Vertical,
                Children = {
                    UniqueHoldingsHeader,
                    new ScrollView
                    {
                        Content = UniqueHoldingsBody,
                        VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true)
                    }
                }
            };
            Content = UniqueHoldingsLayout;
        }

        private Grid SetHeaderGridTemplate(string C1Text, string C2Text, string C3Text)
        {
            Grid returnGrid = new Grid
            {
                Padding = 10,
            };
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });

            returnGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(17, GridUnitType.Absolute) });
            returnGrid.Children.Add(new Label { Text = C1Text, FontAttributes = FontAttributes.Bold }, 0, 0);
            returnGrid.Children.Add(new Label { Text = C2Text, FontAttributes = FontAttributes.Bold }, 1, 0);
            returnGrid.Children.Add(new Label { Text = C3Text, FontAttributes = FontAttributes.Bold }, 2, 0);

            return returnGrid;
        }

        private Grid SetUniqueHoldingsBody()
        {
            Grid returnGrid = new Grid();
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });

            for (int i = 0; i < viewModel.OverlapList.Count; i++)
            {
                returnGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Auto) });
            }
            return returnGrid;
        }

        private void PopulateColumnTemplate(int endIndex, int rowNumber, List<string> sourceList)
        {
            for (int i = 0; i < endIndex; i++)
            {
                UniqueHoldingsBody.Children.Add(new Label
                {
                    Text = sourceList[i],
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, rowNumber, i);
            }
        }
        
        private void PopulateGrid()
        {
            int ov = viewModel.OverlapList.Count;
            int u1 = viewModel.Unique1.Count;
            int u2 = viewModel.Unique2.Count;

            PopulateColumnTemplate(ov, 0, viewModel.OverlapList);
            PopulateColumnTemplate(u1, 1, viewModel.Unique1);
            PopulateColumnTemplate(u2, 2, viewModel.Unique2);

        }
    }
}


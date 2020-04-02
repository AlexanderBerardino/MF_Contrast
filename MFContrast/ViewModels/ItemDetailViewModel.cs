using System.Collections.Generic;
using MFContrast.Models;
using Xamarin.Forms;

namespace MFContrast.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public string FundName;
        public string Id;
        public string Ticker;

        public IList<Holding> HoldingsList { get; set; }
        public Grid ItemDetailGrid { get; set; }
        public Grid HeaderGrid { get; set; }
        public StackLayout Layout { get; set; }


        public ItemDetailViewModel(MutualFund fund)
        {
            FundName = Title = fund.FundName;
            Id = fund.Id;
            Ticker = fund.Ticker;


            HoldingsList = fund.AssetList;

            HeaderGrid = SetHeaderGrid();
            ItemDetailGrid = SetItemDetailGrid();
            PopulateItemDetailGrid();

            Layout = new StackLayout { Orientation = StackOrientation.Vertical };
            AddLayoutChildren();
        }

        public void AddLayoutChildren()
        {
            Layout.Children.Add(HeaderGrid);
            Layout.Children.Add(new ScrollView { Content = ItemDetailGrid, VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true) });
        }
      
        private Grid SetItemDetailGrid()
        {
            Grid returnGrid = new Grid();
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

            for (int i = 0; i < HoldingsList.Count; i++)
            {
                returnGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Auto) });
            }
            return returnGrid;
        }

        private Grid SetHeaderGrid()
        {
            Grid returnGrid = new Grid
            {
                Padding = 10,
            };
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
            returnGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(17, GridUnitType.Absolute) });
            returnGrid.Children.Add(new Label { Text = "Rank", FontAttributes = FontAttributes.Bold }, 0, 0); 
            returnGrid.Children.Add(new Label { Text = "Name", FontAttributes = FontAttributes.Bold }, 1, 0);
            returnGrid.Children.Add(new Label { Text = "Percentage", FontAttributes = FontAttributes.Bold }, 2, 0);

            return returnGrid;
        }

        private void PopulateItemDetailGrid()
        {
            for (int i = 0; i < HoldingsList.Count; i++)
            {
                ItemDetailGrid.Children.Add(new Label
                {
                    Text = HoldingsList[i].Rank,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, 0, i);
                ItemDetailGrid.Children.Add(new Label
                {
                    Text = HoldingsList[i].Name,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle

                }, 1, i);
                ItemDetailGrid.Children.Add(new Label
                {
                    Text = HoldingsList[i].Percentage,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, 2, i);
            }
        }
    }
}

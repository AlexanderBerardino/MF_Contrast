using System.Collections.Generic;

using MFContrast.Models.AlternativeMutualFundModels;
using Xamarin.Forms;

namespace MFContrast.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public string Fund;
        public List<AltMutualFundSlice> AssetList { get; set; }
        public Grid ItemDetailGrid { get; set; }
        public Grid HeaderGrid { get; set; }
        public StackLayout Layout { get; set; }


        public ItemDetailViewModel(AlternativeMutualFundWhole fund)
        {
            Fund = fund.FundName;
            AssetList = fund.AssetList;
            Title = fund.FundName;
            InitializeData();
            Layout = new StackLayout { Orientation = StackOrientation.Vertical };
            SetLayout();

        }
        public void SetLayout()
        {
            Layout.Children.Add(HeaderGrid);
            Layout.Children.Add(new ScrollView { Content = ItemDetailGrid, VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true) });

        }
        public void InitializeData()
        {
            ItemDetailGrid = SetItemDetailGrid();
            HeaderGrid = SetHeaderGrid();
            PopulateGrid();
        }

        private Grid SetItemDetailGrid()
        {
            Grid returnGrid = new Grid();
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

            for (int i = 0; i < AssetList.Count; i++)
            {
                returnGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Auto) });
            }


            return returnGrid;
        }

        private Grid SetHeaderGrid()
        {
            Grid returnGrid = new Grid();
            returnGrid.Padding = 10;
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
            returnGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(10, GridUnitType.Star) });
            returnGrid.Children.Add(new Label { Text = "Rank", FontAttributes = FontAttributes.Bold }, 0, 0); 
            returnGrid.Children.Add(new Label { Text = "Name", FontAttributes = FontAttributes.Bold }, 1, 0);
            returnGrid.Children.Add(new Label { Text = "Percentage", FontAttributes = FontAttributes.Bold }, 2, 0);

            return returnGrid;
        }


        private void PopulateGrid()
        {
            for (int i = 0; i < AssetList.Count; i++)
            {
                ItemDetailGrid.Children.Add(new Label
                {
                    Text = AssetList[i].Rank,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, 0, i);
                ItemDetailGrid.Children.Add(new Label
                {
                    Text = AssetList[i].Name,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle

                }, 1, i);
                ItemDetailGrid.Children.Add(new Label
                {
                    Text = AssetList[i].Percentage,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, 2, i);
            }
        }


    }
}

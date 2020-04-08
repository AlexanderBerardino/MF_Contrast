using System;
using System.Collections.Generic;
using MFContrast.Models;
using Xamarin.Forms;
namespace MFContrast.Services
{
    public interface IGridService
    {
        Grid CreateHeaderGrid(
            string columnOneHeader,
            string columnTwoHeader,
            string columnThreeHeader);

        Grid CreateMainGrid(int rowCount);

        void PopulateMainGrid(
            List<Holding> holdingsList,
            Grid targetGrid);

        void PopulateMainGridByColumn(
            Grid targetGrid,
            List<string> sourceList,
            List<Holding> columnTwoList,
            List<Holding> columnThreeList);
    }

    public class GridService : IGridService
    {
        public Grid CreateHeaderGrid(
            string columnOneHeader,
            string columnTwoHeader,
            string columnThreeHeader)
        {
            Grid returnGrid = new Grid
            {
                Padding = 10,
            };
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });

            returnGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(17, GridUnitType.Absolute) });
            // FontAttributes = FontAttributes.Bold taken out for unit tests
            returnGrid.Children.Add(new Label { Text = columnOneHeader }, 0, 0);
            returnGrid.Children.Add(new Label { Text = columnTwoHeader }, 1, 0);
            returnGrid.Children.Add(new Label { Text = columnThreeHeader }, 2, 0);

            return returnGrid;
        }

        public Grid CreateMainGrid(int rowCount)
        {
            Grid returnGrid = new Grid();
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });

            for (int i = 0; i < rowCount; i++)
            {
                returnGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Auto) });
            }
            return returnGrid;
        }

        public void PopulateMainGrid(List<Holding> holdingsList, Grid targetGrid)
        {
            for (int i = 0; i < holdingsList.Count; i++)
            {
                targetGrid.Children.Add(new Label
                {
                    Text = holdingsList[i].Rank,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, 0, i);
                targetGrid.Children.Add(new Label
                {
                    Text = holdingsList[i].Name,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle

                }, 1, i);
                targetGrid.Children.Add(new Label
                {
                    Text = holdingsList[i].Percentage,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, 2, i);
            }
        }

        private void PopulateColumnTemplate(int rowNumber, List<Holding> sourceList, Grid targetGrid)
        {
            for (int i = 0; i < sourceList.Count; i++)
            {
                targetGrid.Children.Add(new Label
                {
                    Text = string.Join(" ", sourceList[i].Symbol, ":", sourceList[i].Percentage),
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, rowNumber, i);
            }
        }

        private void PopulateColumnTemplate(int rowNumber, List<string> sourceList, Grid targetGrid)
        {
            for (int i = 0; i < sourceList.Count; i++)
            {
                targetGrid.Children.Add(new Label
                {
                    Text = sourceList[i],
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, rowNumber, i);
            }
        }

        public void PopulateMainGridByColumn(
            Grid targetGrid,
            List<string> columnOneList,
            List<Holding> columnTwoList,
            List<Holding> columnThreeList)
        {
            PopulateColumnTemplate(0, columnOneList, targetGrid);
            PopulateColumnTemplate(1, columnTwoList, targetGrid);
            PopulateColumnTemplate(2, columnThreeList, targetGrid);
        }
    }


    public class GridServiceClient: GridService
    {
        public Grid HeaderGrid { get; set; }
        public Grid MainGrid { get; set; }

        public GridServiceClient(string[] headerText, List<Holding> holdingList)
        {
            if (ConstructorValidation(headerText) && ConstructorValidation(holdingList))
            {
                HeaderGrid = CreateHeaderGrid(headerText[0], headerText[1], headerText[2]);
                MainGrid = CreateMainGrid(holdingList.Count);
                PopulateMainGrid(holdingList, MainGrid);
            }
        }

        private bool ConstructorValidation(string[] input)
        {
            if(input.Length == 3)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Expected Length 3, Actual Length: " + input.Length);
            }
        }

        private bool ConstructorValidation(List<Holding> holdingsList)
        {
            if(holdingsList is null)
            {
                throw new ArgumentNullException("Input List of Holdings null");
            }
            else
            {
                return true;
            }
        }
    }
}

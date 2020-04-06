using System;
using System.Collections.Generic;
using MFContrast.Models;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareOverlapPage : ContentPage
    {
        // PostCompareOverlapViewModel viewModel;
        PostCompareOverlapViewModelV2 viewModel;

        public string UpperTicker1 => viewModel.Fund1.Ticker.ToUpper();
        public string UpperTicker2 => viewModel.Fund2.Ticker.ToUpper();
        public ListView StatsView { get; set; }
        public Grid GridBody { get; set; }
        public Grid GridHead { get; set; }
        public StackLayout PageOneMainLayout { get; set; }

        public PostCompareOverlapPage(PostCompareOverlapViewModelV2 viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;

            StatsView = SetListView();
            GridHead = SetHeaderGridTemplate("Overlap", string.Join(separator: " ", UpperTicker1 + "Unique"), string.Join(separator: " ", UpperTicker2 + "Unique"));
            GridBody = SetUniqueHoldingsBody();
            PopulateGrid();
            PageOneMainLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 20,
                Children = {
                    StatsView,
                    GridHead,
                    new ScrollView
                    {
                        Content = GridBody,
                        VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true)
                    }
                }
            };
            Content = PageOneMainLayout;
        }

        // Numbers Formatted to End
        private ListView SetListView()
        {
            ListView listView = new ListView
            {
                ItemsSource = new string[]
                {
                    string.Join(" ","Overlap Size:", viewModel.OverlapListSize.ToString()),
                    string.Join(" ", UpperTicker1, "# of Unique Holdings:", viewModel.U1Size.ToString()),
                    string.Join(" ", UpperTicker2, "# of Unique Holdings:", viewModel.U2Size.ToString()),
                    string.Join(" ", UpperTicker2, "in", UpperTicker1+":", string.Format("{0:0.#####}", viewModel.F2InF1), "%"),
                    string.Join(" ", UpperTicker1, "in", UpperTicker2+":", string.Format("{0:0.#####}", viewModel.F1InF2), "%"),
                    string.Join(" ", "Overlap By Weight:", string.Format("{0:0.#####}", viewModel.OverlapPercentage), "%"),
                    string.Join(" ", UpperTicker1, "Top Ten:", string.Format("{0:0.#####}", viewModel.F1TopTen), "%"),
                    string.Join(" ", UpperTicker2, "Top Ten:", string.Format("{0:0.#####}", viewModel.F2TopTen), "%"),
                }
            };
            return listView;           
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
            int max3 = Math.Max(viewModel.OverlapList.Count, Math.Max(viewModel.Unique1.Count, viewModel.Unique2.Count));
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            returnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });

            for (int i = 0; i < max3; i++)
            {
                returnGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Auto) });
            }
            return returnGrid;
        }

        private void PopulateColumnTemplate(int endIndex, int rowNumber, List<Holding> sourceList)
        {
            for (int i = 0; i < endIndex; i++)
            {
                GridBody.Children.Add(new Label
                {
                    Text = string.Join(" ", sourceList[i].Symbol, ":", sourceList[i].Percentage),
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, rowNumber, i);
            }
        }
        private void PopulateColumnTemplateString(int endIndex, int rowNumber, List<string> sourceList)
        {
            for (int i = 0; i < endIndex; i++)
            {
                GridBody.Children.Add(new Label
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

            PopulateColumnTemplateString(ov, 0, viewModel.OverlapList);
            PopulateColumnTemplate(u1, 1, viewModel.Unique1);
            PopulateColumnTemplate(u2, 2, viewModel.Unique2);

        }
    }
}

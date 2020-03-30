using System.Collections;
using System.Collections.Generic;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareOverlapPage : ContentPage
    {
        PostCompareOverlapViewModel viewModel;
        public Grid UniqueHoldingsBody { get; set; }
        public Grid UniqueHoldingsHeader { get; set; }
        public StackLayout UniqueHoldingsLayout { get; set; }
        public ListView StatsView { get; set; }
        public string Name1 => viewModel.Fund1.FundName;
        public string Name2 => viewModel.Fund2.FundName;
        public string UpperTicker1 => viewModel.Fund1.Ticker.ToUpper();
        public string UpperTicker2 => viewModel.Fund2.Ticker.ToUpper();



        public PostCompareOverlapPage(PostCompareOverlapViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            UniqueHoldingsHeader = SetHeaderGridTemplate("Overlap", string.Join(separator:" ", UpperTicker1 + "Unique"), string.Join(separator: " ", UpperTicker2 + "Unique"));
            UniqueHoldingsBody = SetUniqueHoldingsBody();
            PopulateGrid();
            UniqueHoldingsLayout = new StackLayout { Orientation = StackOrientation.Vertical };
            AddLayoutChildren();
            Content = UniqueHoldingsLayout;
        }
        private ListView SetListView()
        {
            ListView listView = new ListView
            {
                ItemsSource = new string[]
            {
                "Overlap Size: " + viewModel.OverlapListSize.ToString(),
                Name1 + string.Join("", "(", UpperTicker1 + ") ") + " # of Unique Holdings: " + viewModel.U1Size.ToString(),
                Name2 + string.Join("", "(", UpperTicker2 + ") ") + " # of Unique Holdings: " + viewModel.U2Size.ToString(),
                string.Join(" ", Name2, "in", Name1) + ": " + string.Format("{0:0.#####}", viewModel.F2InF1) + " %",
                string.Join(" ", Name1, "in", Name2) + ": " + string.Format("{0:0.#####}", viewModel.F1InF2) + " %",
                "Overlap By Weight: " + string.Format("{0:0.#####}", viewModel.OverlapPercentage) + " %"
            }
            };
            return listView;           
        }

        private void AddLayoutChildren()
        {
            UniqueHoldingsLayout.Children.Add(SetListView());
            UniqueHoldingsLayout.Children.Add(UniqueHoldingsHeader);
            UniqueHoldingsLayout.Children.Add(new ScrollView { Content = UniqueHoldingsBody, VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true) });
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

        private void PopulateOverlapColumn()
        {
            for (int i = 0; i < viewModel.OverlapList.Count; i++)
            {
                UniqueHoldingsBody.Children.Add(new Label
                {
                    Text = viewModel.OverlapList[i],
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle
                }, 0, i);
            }
        }

        private void PopulateUnique1Column()
        {
            for (int i=0; i<viewModel.Unique1.Count; i++)
            {
                UniqueHoldingsBody.Children.Add(new Label
                {
                    Text = viewModel.Unique1[i],
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle

                }, 1, i);
            }
        }
        
        private void PopulateUnique2Column()
        {
            for (int i = 0; i < viewModel.Unique2.Count; i++)
            {
                UniqueHoldingsBody.Children.Add(new Label
                {
                    Text = viewModel.Unique2[i],
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle

                }, 2, i);
            }
        }
        
        /*
        private void PopulateUnique2Column()
        {
            List<Label> labelList = new List<Label>();


            foreach(KeyValuePair<string, double> pair in viewModel.topUnique1)
            {    
                labelList.Add(new Label
                {
                    Text = string.Format("{0} : {1} %", pair.Key, pair.Value),
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Style = Device.Styles.ListItemDetailTextStyle

                });           
            }
            while(labelList.GetEnumerator().Current != null)
            {

            }
        }
        */
        private void PopulateGrid()
        {
            PopulateOverlapColumn();
            PopulateUnique1Column();
            PopulateUnique2Column();
        }
    }
}

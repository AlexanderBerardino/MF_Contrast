
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

        public PostCompareOverlapPage(PostCompareOverlapViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            UniqueHoldingsHeader = SetHeaderGridTemplate("Overlap", "Unique in Fund1", "Unique in Fund2");
            UniqueHoldingsBody = SetUniqueHoldingsBody();
            PopulateGrid();
            UniqueHoldingsLayout = new StackLayout { Orientation = StackOrientation.Vertical };
            AddLayoutChildren();
            Content = UniqueHoldingsLayout;
        }
        public ListView setListView()
        {
            ListView listView = new ListView
            {
                ItemsSource = new string[]
            {
                "Overlap Size: " + viewModel.OverlapListSize.ToString(),
                "Fund1 # of Unique Holdings: " + viewModel.U1Size.ToString(),
                "Fund2 # of Unique Holdings: " + viewModel.U2Size.ToString(),
                "Fund2 in Fund1: " + string.Format("{0:0.#####}", viewModel.F2InF1) + " %",
                "Fund1 in Fund2: " + string.Format("{0:0.#####}", viewModel.F1InF2) + " %",
                "Overlap By Weight: " + string.Format("{0:0.#####}", viewModel.OverlapPercentage) + " %"
            }
            };
            return listView;           
        }

        public void AddLayoutChildren()
        {
            UniqueHoldingsLayout.Children.Add(setListView());
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

        private void PopulateGrid()
        {
            PopulateOverlapColumn();
            PopulateUnique1Column();
            PopulateUnique2Column();
        }
    }
}

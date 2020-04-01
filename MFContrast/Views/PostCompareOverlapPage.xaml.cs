using System.Collections;
using System.Collections.Generic;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareOverlapPage : ContentPage
    {
        PostCompareOverlapViewModel viewModel;
    
        public string UpperTicker1 => viewModel.Fund1.Ticker.ToUpper();
        public string UpperTicker2 => viewModel.Fund2.Ticker.ToUpper();
        public string Name1 => viewModel.Fund1.FundName;
        public string Name2 => viewModel.Fund2.FundName;
        public ListView StatsView { get; set; }
        public StackLayout PageOneMainLayout { get; set; }


        public PostCompareOverlapPage(PostCompareOverlapViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
           
            StatsView = SetListView();
            PageOneMainLayout = new StackLayout {
                Orientation = StackOrientation.Vertical,
                Children = { StatsView }
            };
            Content = PageOneMainLayout;
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
    }
}

using System.Collections.Generic;
using MFContrast.ViewModels;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Entry = Microcharts.Entry;

namespace MFContrast.Views
{
    public partial class PostCompareGraphicPage : ContentPage
    {
        public PostCompareOverlapViewModel ViewModel { get; set; }

        public List<Entry> OverlapEntryList { get; set; }
        public List<Entry> RadialEntryList { get; set; }

        public PostCompareGraphicPage(PostCompareOverlapViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;

            OverlapEntryList = new List<Entry>
            {
                 new Entry(ViewModel.OverlapListSize)
                {
                    Color = SKColor.Parse("#F7EF26"),
                    Label = "Overlap",
                    ValueLabel = string.Join(" ", ViewModel.OverlapListSize.ToString(), "Holdings"),
                    TextColor = SKColor.Parse("#0A0909")
                },
                new Entry(ViewModel.U1Size)
                {
                    Color = SKColor.Parse("#EA2325"),
                    Label = string.Join(" ", ViewModel.Fund1.Ticker.ToUpper(), "Only"),
                    ValueLabel = string.Join(" ", ViewModel.U1Size.ToString(), "Holdings"),
                    TextColor = SKColor.Parse("#0A0909")
                },
                new Entry(ViewModel.U2Size)
                {
                    Color = SKColor.Parse("#5FD419"),
                    Label = string.Join(" ", ViewModel.Fund2.Ticker.ToUpper(), "Only"),
                    ValueLabel = string.Join(" ", ViewModel.U2Size.ToString(), "Holdings"),
                    TextColor = SKColor.Parse("#0A0909")
                },
                new Entry(0)
                {
                    // This entry corrects a formatting issue, no data added here.
                    // With three data points it formats like as a triangle, with the middle point being covered
                    // by the chart itself
                }
            };

            RadialEntryList = new List<Entry>
            {
                new Entry(0),

                new Entry((float)ViewModel.F2InF1)
                {
                    Color = SKColor.Parse("#EA2325"),
                    Label = string.Join(" ", ViewModel.Fund2.Ticker.ToUpper(), "In", ViewModel.Fund1.Ticker.ToUpper()),
                    ValueLabel = string.Join("", string.Format("{0:0.#####}", ViewModel.F2InF1), "%"),
                    TextColor = SKColor.Parse("#0A0909")
                },

                new Entry((float)ViewModel.F1InF2)
                {
                    Color = SKColor.Parse("#5FD419"),
                    Label = string.Join(" ", ViewModel.Fund1.Ticker.ToUpper(), "In", ViewModel.Fund2.Ticker.ToUpper()),
                    ValueLabel = string.Join("", string.Format("{0:0.#####}", ViewModel.F1InF2), "%"),
                    TextColor = SKColor.Parse("#0A0909")
                },

                new Entry(100)
            };

            Chart1.Chart = new DonutChart
            {
                HoleRadius = 0.20f,
                LabelTextSize = 40,
                Margin = 50,
                Entries = OverlapEntryList,
            };

            Chart2.Chart = new RadialGaugeChart
            {
                Entries = RadialEntryList,
                LabelTextSize = 32,
                Margin = 30
            };
        }
    }
}

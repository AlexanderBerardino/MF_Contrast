using System.Collections.Generic;
using MFContrast.ViewModels;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using Xamarin.Forms;
using Entry = Microcharts.Entry;

namespace MFContrast.Views
{
    public partial class PostCompareGraphicPage : ContentPage
    {
        // public float LabelSize { get; set; }
        public ChartView ChartView { get; set; }

        public PostCompareOverlapViewModel ViewModel { get; set; }

        public List<Entry> EntryList { get; set; }        

        public PostCompareGraphicPage(PostCompareOverlapViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            // LabelSize = 60f;
            EntryList = new List<Entry>
            {
                 new Entry(ViewModel.OverlapListSize)
                {
                    Color = SKColor.Parse("#F7EF26"),
                    Label = "Overlap",
                    ValueLabel = ViewModel.OverlapListSize.ToString(),
                    TextColor = SKColor.Parse("#000000")
                },
                new Entry(ViewModel.U1Size)
                {
                    Color = SKColor.Parse("#EA2325"),
                    Label = string.Join(" ", ViewModel.Fund1.FundName, "Only"),
                    ValueLabel = ViewModel.U1Size.ToString(),
                    TextColor = SKColor.Parse("#000000")
                },
                new Entry(ViewModel.U2Size)
                {
                    Color = SKColor.Parse("#5FD419"),
                    Label = string.Join(" ", ViewModel.Fund2.FundName, "Only"),
                    ValueLabel = ViewModel.U2Size.ToString(),
                    TextColor = SKColor.Parse("#000000")
                }
            };

            Chart1.Chart = new DonutChart {
                HoleRadius = 0.20f,
                // LabelTextSize = (float)Convert.ToDouble(Device.GetNamedSize(NamedSize.Large, typeof(Label))),
                LabelTextSize = 30,
                Margin = 50,
                Entries = EntryList,
            };
        }

        // To add below, you must add: PaintSurface="OnPaintSurface" To ChartView properties in Xaml 

        /*
        public void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            float skScale = (float)(e.Info.Height / ((SKCanvasView)sender).Height);

            // Scale the chart label font size to be the same as the standard labels on the screen
            if (skScale != 0)
                Chart1.Chart.LabelTextSize = LabelSize * skScale;

            // Set the height of the chart view so that it takes up the full width of the screen minus the room needed for the labels
            // We need to limit the height of the chart element to prevent the chart labels from being covered by the chart
            if (skScale != 0)
            {
                int magicLabelMargin = (int)LabelSize * 13;
                Chart1.HeightRequest = Chart1.Width - magicLabelMargin;
            }
        }
        */
    }
}

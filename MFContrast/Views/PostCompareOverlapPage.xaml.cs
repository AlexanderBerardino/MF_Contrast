using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareOverlapPage : ContentPage
    {
        public PostCompareOverlapStatisticalViewModel ViewModel { get; set; }

        public PostCompareOverlapPage(PostCompareOverlapStatisticalViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel = viewModel;
        }
    }
}

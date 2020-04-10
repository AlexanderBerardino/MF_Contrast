using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareOverlapPage : ContentPage
    {
        public PostCompareOverlapViewModelSpecific ViewModel { get; set; }

        public PostCompareOverlapPage(PostCompareOverlapViewModelSpecific viewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel = viewModel;
        }
    }
}

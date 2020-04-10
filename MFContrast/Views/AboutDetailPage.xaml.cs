using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class AboutDetailPage : ContentPage
    {
        public AboutDetailViewModel ViewModel { get; set; }

        public AboutDetailPage(AboutDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel = viewModel;
            AboutLabel.Style = Device.Styles.BodyStyle;
        }
    }
}

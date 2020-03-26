
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareOverlapPage : ContentPage
    {
        PostCompareOverlapViewModel viewModel;

        public PostCompareOverlapPage(PostCompareOverlapViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        /*

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Unique1.Count == 0)
            {
                viewModel.LoadItemsCommandOne.Execute(null);
            }

            if (viewModel.Unique2.Count == 0)
            {
                viewModel.LoadItemsCommandTwo.Execute(null);
            }
        }
        */



    }
}

using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareCarouselPage : CarouselPage
    {
        public PostCompareCarouselPage(PostCompareOverlapViewModelV2 viewModel)
        {
            InitializeComponent();
            PostCompareOverlapViewModelSpecific specific = new PostCompareOverlapViewModelSpecific(viewModel.Fund1, viewModel.Fund2);
            PostCompareGridViewModel gridViewModel = new PostCompareGridViewModel(viewModel.Fund1, viewModel.Fund2);

            PostCompareOverlapPage OverlapPage = new PostCompareOverlapPage(specific);
            PostCompareGridPage GridPage = new PostCompareGridPage(gridViewModel);
            PostCompareGraphicPage GraphicPage = new PostCompareGraphicPage(viewModel);

            Children.Add(OverlapPage);
            Children.Add(GridPage);
            Children.Add(GraphicPage);
        }
    }
}

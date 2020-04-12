using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareCarouselPage : CarouselPage
    {
        public PostCompareCarouselPage(PostCompareOverlapViewModelV2 viewModel)
        {
            InitializeComponent();
            PostCompareOverlapStatisticalViewModel specific = new PostCompareOverlapStatisticalViewModel(viewModel.Fund1, viewModel.Fund2);
            PostCompareOverlapGridViewModel gridViewModel = new PostCompareOverlapGridViewModel(viewModel.Fund1, viewModel.Fund2);

            PostCompareOverlapPage OverlapPage = new PostCompareOverlapPage(specific);
            PostCompareGridPage GridPage = new PostCompareGridPage(gridViewModel);
            PostCompareGraphicPage GraphicPage = new PostCompareGraphicPage(viewModel);

            Children.Add(OverlapPage);
            Children.Add(GridPage);
            Children.Add(GraphicPage);
        }
    }
}

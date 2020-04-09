using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareCarouselPage : CarouselPage
    {
        public PostCompareCarouselPage(PostCompareOverlapViewModelV2 viewModel)
        {
            InitializeComponent();

            // PostCompareCarouselPage: CarouselPage
            // Created via 'Compare' button Event in ComparePage

            // CarouselPage, 3 children: PostCompareOverlapPage, PostCompareListPage, PostCompareGraphicPage

            PostCompareOverlapViewModelSpecific specific = new PostCompareOverlapViewModelSpecific(viewModel.Fund1, viewModel.Fund2);
            PostCompareOverlapPage OverlapPage = new PostCompareOverlapPage(specific);
            PostCompareListPage CarouselListPage = new PostCompareListPage(viewModel);
            PostCompareGraphicPage GraphicPage = new PostCompareGraphicPage(viewModel);

            Children.Add(OverlapPage);
            Children.Add(CarouselListPage);
            Children.Add(GraphicPage);
        }
    }
}

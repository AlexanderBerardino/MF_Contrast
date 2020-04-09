using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareCarouselPage : CarouselPage
    {
        public PostCompareCarouselPage(PostCompareOverlapViewModelV2 viewModel)
        {
            InitializeComponent();

            // PostCompareCarouselPage is a CarouselPage which is created upon
            // users clicking the 'Compare' button in ComparePage

            // This CarouselPage has three children: a PostCompareOverlapPage,
            // a PostCompareListPage, and a PostCompareGraphicPage
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

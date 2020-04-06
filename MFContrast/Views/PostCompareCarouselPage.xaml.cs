using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareCarouselPage : CarouselPage
    {
        public PostCompareCarouselPage(PostCompareOverlapViewModel viewModel)
        {
            InitializeComponent();

            // PostCompareCarouselPage is a CarouselPage which is created upon
            // users clicking the 'Compare' button in ComparePage
            // This CarouselPage has three children: a PostCompareOverlapPage,
            // a PostCompareListPage, and a PostCompareGraphicPage
            PostCompareOverlapViewModelV2 tempv2 = new PostCompareOverlapViewModelV2(viewModel.Fund1, viewModel.Fund2);

            PostCompareOverlapPage OverlapPage = new PostCompareOverlapPage(tempv2);
            PostCompareListPage CarouselListPage = new PostCompareListPage(viewModel);
            PostCompareGraphicPage graphicPage = new PostCompareGraphicPage(viewModel);
            Children.Add(OverlapPage);
            Children.Add(CarouselListPage);
            Children.Add(graphicPage);

        }

    }
}

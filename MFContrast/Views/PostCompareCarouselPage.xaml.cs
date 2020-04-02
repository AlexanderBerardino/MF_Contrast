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
            PostCompareOverlapPage OverlapPage = new PostCompareOverlapPage(viewModel);
            PostCompareListPage CarouselListPage = new PostCompareListPage(viewModel);
            PostCompareGraphicPage graphicPage = new PostCompareGraphicPage(viewModel);
            Children.Add(OverlapPage);
            Children.Add(CarouselListPage);
            Children.Add(graphicPage);

        }

    }
}

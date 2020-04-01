using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareCarouselPage : CarouselPage
    {
        public PostCompareCarouselPage(PostCompareOverlapViewModel viewModel)
        {
            InitializeComponent();

            PostCompareOverlapPage OverlapPage = new PostCompareOverlapPage(viewModel);
            PostCompareListPage CarouselListPage = new PostCompareListPage(viewModel);
            PostCompareGraphicPage graphicPage = new PostCompareGraphicPage(viewModel);
            Children.Add(OverlapPage);
            Children.Add(CarouselListPage);
            Children.Add(graphicPage);

        }

    }
}

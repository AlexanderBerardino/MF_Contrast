using System;
using System.Collections.Generic;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostCompareCarouselPage : CarouselPage
    {
        PostCompareOverlapViewModel viewModel;
   

        public PostCompareCarouselPage(PostCompareOverlapViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;

            PostCompareOverlapPage OverlapPage = new PostCompareOverlapPage(viewModel);
            PostCompareListPage CarouselListPage = new PostCompareListPage(viewModel);
            Children.Add(OverlapPage);
            Children.Add(CarouselListPage);

        }

    }
}

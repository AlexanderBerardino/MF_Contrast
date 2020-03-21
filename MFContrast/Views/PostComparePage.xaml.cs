using System;
using System.Collections.Generic;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostComparePage : ContentPage
    {
        public PostCompareViewModel viewModel;

        public PostComparePage(PostCompareViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            BindingContext = viewModel;
        }

        
    }
}

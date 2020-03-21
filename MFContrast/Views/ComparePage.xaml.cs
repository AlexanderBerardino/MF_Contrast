using System;
using System.Collections.Generic;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class ComparePage : ContentPage
    {
        public CompareViewModel viewModel;

        public ComparePage()
        {
            InitializeComponent();
            viewModel = new CompareViewModel();
            BindingContext = viewModel;
        }

        public ComparePage(CompareViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            BindingContext = this.viewModel;
        }
    }
}

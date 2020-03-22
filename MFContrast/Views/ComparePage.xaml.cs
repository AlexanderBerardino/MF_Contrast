using System;
using System.Collections.Generic;
using System.ComponentModel;
using MFContrast.Models.AlternativeMutualFundModels;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views

{
    [DesignTimeVisible(false)]
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

        async void ContrastClicked(object sender, EventArgs e)
        {
            AlternativeMutualFundWhole f1 = new AlternativeMutualFundWhole { Id = "0", FundName = "Vanguard" };
            AlternativeMutualFundWhole f2 = new AlternativeMutualFundWhole { Id = "1", FundName = "Fidelity" };
            await Navigation.PushAsync(new PostComparePage(new PostCompareViewModel(f1, f2)));
        }

    }
}

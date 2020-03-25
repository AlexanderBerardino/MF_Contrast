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
            BindingContext = this.viewModel = viewModel;
            Content = viewModel.PC_ParentLayout;
        }

        async void OnOverlapSelected(object sender, SelectedItemChangedEventArgs args)
        {

            await Navigation.PushAsync(new PostCompareOverlapPage(new PostCompareOverlapViewModel(viewModel.CompareService)));
 
        }

        /*
        async void OnStatisticSelected(object sender, SelectedItemChangedEventArgs args)
        {

        }
        */
    }
}

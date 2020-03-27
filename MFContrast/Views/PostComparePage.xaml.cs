using System;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class PostComparePage : ContentPage
    {
        public PostCompareViewModel viewModel;
        public StackLayout PC_ParentLayout { get; set; }


        public PostComparePage(PostCompareViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            PC_ParentLayout = new StackLayout();


            Button OverlapNavigation = new Button
            {
                Text = "Overlap View",
                FontSize = 20,
                Padding = 10,
            };

            Button StatisticalNavigation = new Button
            {
                Text = "Statistical View",
                FontSize = 20,
                Padding = 10
            };


            OverlapNavigation.Clicked += OnOverlapSelected;
            PC_ParentLayout.Children.Add(OverlapNavigation);
            PC_ParentLayout.Children.Add(StatisticalNavigation);

            Content = PC_ParentLayout;

        }

        public async void OnOverlapSelected(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PostCompareOverlapPage(new PostCompareOverlapViewModel(viewModel.Fund1, viewModel.Fund2)));
        }

        /*
        async void OnStatisticSelected(object sender, SelectedItemChangedEventArgs args)
        {

        }
        */
    }
}

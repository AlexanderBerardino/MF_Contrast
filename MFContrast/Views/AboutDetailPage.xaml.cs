using System;
using System.Collections.Generic;
using MFContrast.Models;
using MFContrast.ViewModels;
using Xamarin.Forms;

namespace MFContrast.Views
{
    public partial class AboutDetailPage : ContentPage
    {
        public AboutDetailViewModel viewModel { get; set; }

        public AboutDetailPage(AboutDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            AboutLabel.Style = Device.Styles.BodyStyle;
        }
    }
}

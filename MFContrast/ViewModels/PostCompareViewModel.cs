using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MFContrast.Models;
using MFContrast.Services;

using System.Diagnostics;
using Xamarin.Forms;
using MFContrast.Views;

namespace MFContrast.ViewModels
{
    public class PostCompareViewModel : BaseViewModel
    {
        public CalculatePostCompare CompareService;
        public StackLayout PC_ParentLayout { get; set; }


        public PostCompareViewModel(MutualFund Fund1, MutualFund Fund2)
        {
            CompareService = new CalculatePostCompare(Fund1, Fund2);
            PC_ParentLayout = new StackLayout();

            Button OverlapNavigation = new Button
            {
                Text = "Overlap View",
                FontSize = 20,
                Padding = 10
                     
            };

            Button StatisticalNavigation = new Button
            {
                Text = "Statistical View",
                FontSize = 20,
                Padding = 10
            };

            PC_ParentLayout.Children.Add(OverlapNavigation);
            PC_ParentLayout.Children.Add(StatisticalNavigation);
        
        }

        


    }
}

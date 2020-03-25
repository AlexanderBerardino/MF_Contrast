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
        public PostCompareModel PostCompareModel { get; set; }


        public PostCompareViewModel(MutualFund Fund1, MutualFund Fund2)
        {
            PostCompareModel = new PostCompareModel(Fund1, Fund2);
           
        
        }






    }
}

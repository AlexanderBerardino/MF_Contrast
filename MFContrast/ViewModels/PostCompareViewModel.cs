using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MFContrast.Models.AlternativeMutualFundModels;
using MFContrast.Services;

using System.Diagnostics;
using Xamarin.Forms;

namespace MFContrast.ViewModels
{
    public class PostCompareViewModel : BaseViewModel
    {
        public CalculatePostCompare CompareService;
        public ObservableCollection<string> AssetOverlap { get; set; }
        public Command LoadItemsCommand { get; set; }

        public PostCompareViewModel(AlternativeMutualFundWhole Fund1, AlternativeMutualFundWhole Fund2)
        {
            CompareService = new CalculatePostCompare(Fund1, Fund2);
            AssetOverlap = new ObservableCollection<string>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                AssetOverlap.Clear();
                var assets = await CompareService.CalculateOverlap();
                foreach (var asset in assets)
                {
                    AssetOverlap.Add(asset);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

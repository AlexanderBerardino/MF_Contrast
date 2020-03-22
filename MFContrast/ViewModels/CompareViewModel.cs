using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MFContrast.Models.AlternativeMutualFundModels;
using Xamarin.Forms;

namespace MFContrast.ViewModels
{
    public class CompareViewModel : BaseViewModel
    {
        public ObservableCollection<AlternativeMutualFundWhole> Funds { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CompareViewModel()
        {
            Funds = new ObservableCollection<AlternativeMutualFundWhole>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Funds.Clear();
                var funds = await MutualFundDataStore.GetItemsAsync();
                foreach (var fund in funds)
                {
                    Funds.Add(fund);
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

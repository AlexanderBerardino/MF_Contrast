using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using MFContrast.Models.AlternativeMutualFundModels;

namespace MFContrast.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<AlternativeMutualFundWhole> Funds { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
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
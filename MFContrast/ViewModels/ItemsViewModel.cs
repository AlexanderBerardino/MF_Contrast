using System.Collections.ObjectModel;
using Xamarin.Forms;
using MFContrast.Models;

namespace MFContrast.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<MutualFund> Funds { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Funds = new ObservableCollection<MutualFund>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(Funds));
        }
    }
}
using System.Collections.ObjectModel;
using MFContrast.Models;
using Xamarin.Forms;

namespace MFContrast.ViewModels
{
    public class CompareViewModel : BaseViewModel
    {
        public ObservableCollection<MutualFund> Funds { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CompareViewModel()
        {
            Funds = new ObservableCollection<MutualFund>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(Funds));
        }
    }
}

using System.Collections.Generic;
using MFContrast.Models;

namespace MFContrast.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public string FundName { get; set; }
        public List<Holding> HoldingsList { get; set; }

        public ItemDetailViewModel(MutualFund fund)
        {
            FundName = Title = fund.FundName;
            HoldingsList = fund.AssetList;
        }
    }
}

using MFContrast.Models.AlternativeMutualFundModels;


namespace MFContrast.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public AlternativeMutualFundWhole Fund;

        public ItemDetailViewModel(AlternativeMutualFundWhole fund = null)
        {
            Title = fund?.FundName;
            Fund = fund ?? new AlternativeMutualFundWhole();
        }

        public string FundName
        {
            get => Fund.FundName;
            set
            {
                Fund.FundName = value;
                OnPropertyChanged();
            }
        }
        
    }
}

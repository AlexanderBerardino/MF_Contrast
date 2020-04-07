using MFContrast.Models;

namespace MFContrast.ViewModels
{
    public class PostCompareViewModel : BaseViewModel
    {
        public MutualFund Fund1;
        public MutualFund Fund2;

        public PostCompareViewModel(MutualFund Fund1, MutualFund Fund2)
        {
            this.Fund1 = Fund1;
            this.Fund2 = Fund2;
        }

    }
}

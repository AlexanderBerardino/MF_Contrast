using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models;

namespace MFContrast.Services
{
    public interface ICalculatePostCompare
    {
        Task<IList<string>> CalculateOverlap(MutualFund fund1, MutualFund fund2);
        Task<IList<string>> CalculateUniqueHoldings1(MutualFund fund1, MutualFund fund2);
        Task<IList<string>> CalculateUniqueHoldings2(MutualFund fund1, MutualFund fund2);

        float GetOverlapByWeight();
        float Get1In2();
        float Get2In1();
        Task<int> GetOverlapHoldingsNumber(MutualFund fund1, MutualFund fund2);

    }
}

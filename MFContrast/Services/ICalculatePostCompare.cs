using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFContrast.Services
{
    public interface ICalculatePostCompare
    {
        Task<IList<string>> CalculateOverlap();
        Task<IList<string>> CalculateUniqueHoldings1();
        Task<IList<string>> CalculateUniqueHoldings2();

        float GetOverlapByWeight();
        float Get1In2();
        float Get2In1();
        Task<int> GetOverlapHoldingsNumber();

    }
}

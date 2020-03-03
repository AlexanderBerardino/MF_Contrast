using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models;

namespace MFContrast.Services
{
    public interface IMutualFundDataStore
    {
        Task<string> AddMutualFundSliceAsync(MutualFundSlice myFund);
        Task<bool> UpdateMutualFundSlicesAsync(MutualFundSlice myFund);
        Task<IList<MutualFundSlice>> GetMutualFundSlicesAsync();
        Task<IList<string>> GetMutualFundSliceNamesAsync();


        // Task<IList<MutualFund>> GetNotesAsync();
    }
}

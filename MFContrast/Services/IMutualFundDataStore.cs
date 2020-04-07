using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models;

namespace MFContrast.Services
{
    public interface IMutualFundDataStore
    {
        Task<string> AddItemAsync(MutualFund fund);
        Task<MutualFund> GetItemAsync(string id);
        Task<IList<MutualFund>> GetItemsAsync();
    }
}

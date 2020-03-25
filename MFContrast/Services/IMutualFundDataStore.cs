using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models;

namespace MFContrast.Services
{
    public interface IMutualFundDataStore
    {
      
        // Not sure if this interface needs AddItemAsync, DeleteItemAsync, or UpdateItemAsync
        // as the data will be a list not an observable collection
        // Might be subject to change if it ever makes sense to have the user
        // be able to alter the Funds in any way i.e see how removing an asset from
        // a fund alters the comparison

        Task<string> AddItemAsync(MutualFund fund);
        Task<MutualFund> GetItemAsync(string id);
        Task<IList<MutualFund>> GetItemsAsync();
        // Task<IList<Holding>> GetAssetsAsync(string id);


    }
}

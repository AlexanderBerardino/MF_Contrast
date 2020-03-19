using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models;
using MFContrast.Models.AlternativeMutualFundModels;

namespace MFContrast.Services
{
    public interface IMutualFundDataStore
    {
      
        // Not sure if this interface needs AddItemAsync, DeleteItemAsync, or UpdateItemAsync
        // as the data will be a list not an observable collection
        // Might be subject to change if it ever makes sense to have the user
        // be able to alter the Funds in any way i.e see how removing an asset from
        // a fund alters the comparison

        Task<string> AddItemAsync(AlternativeMutualFundWhole fund);
        Task<bool> UpdateItemAsync(AlternativeMutualFundWhole fund);
        Task<bool> DeleteItemAsync(string id);
        Task<AlternativeMutualFundWhole> GetItemAsync(string id);

        Task<IList<AlternativeMutualFundWhole>> GetItemsAsync();


    }
}

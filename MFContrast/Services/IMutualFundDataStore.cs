using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models;
using MFContrast.Models.AlternativeMutualFundModels;

namespace MFContrast.Services
{
    public interface IMutualFundDataStore
    {
      

        Task<string> AddItemAsync(AlternativeMutualFundWhole fund);
        Task<bool> UpdateItemAsync(AlternativeMutualFundWhole fund);
        Task<bool> DeleteItemAsync(string id);
        Task<AlternativeMutualFundWhole> GetItemAsync(string id);

        Task<IList<AlternativeMutualFundWhole>> GetItemsAsync();


    }
}

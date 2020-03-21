using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models.AlternativeMutualFundModels;

namespace MFContrast.Services.CsvConversionPath
{
    public interface IAssetDataStore
    {
        Task<string> AddAssetAsync(AltMutualFundSlice fundSlice);
        // Task<bool> UpdateNoteAsync(Note courseNote);
        Task<AltMutualFundSlice> GetAssetAsync(string rank);
        Task<IList<AltMutualFundSlice>> GetAssetsAsync();
        Task<IList<string>> GetAssetAsync();

    }
}

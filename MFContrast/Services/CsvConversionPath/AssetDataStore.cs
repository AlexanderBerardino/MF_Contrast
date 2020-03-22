using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models.AlternativeMutualFundModels;

namespace MFContrast.Services.CsvConversionPath
{
    public class AssetDataStore : ConvertCsvTable, IAssetDataStore
    {
      
        private readonly List<AltMutualFundSlice> assetList;

        public AssetDataStore() : base()
        {
            assetList = initializeAssetList();

        }

        private List<AltMutualFundSlice> initializeAssetList()
        {
            List<AltMutualFundSlice> _assetList = new List<AltMutualFundSlice>();
            for(int i=0; i < csvTable.Rows.Count; i++)
            {
                _assetList.Add(new AltMutualFundSlice { Name = csvTable.Rows[i][4].ToString(),
                                                       Rank = csvTable.Rows[i][1].ToString(),
                                                       Percentage = csvTable.Rows[i][3].ToString(),
                                                       Symbol=csvTable.Rows[i][5].ToString() });
            }
            return _assetList;
        }

        public async Task<IList<AltMutualFundSlice>> GetAssetsAsync()
        {
            var returnAsset = new List<AltMutualFundSlice>();
            foreach(var asset in assetList)
            {
                returnAsset.Add(CopyAsset(asset));
            }
            return await Task.FromResult(returnAsset);
        }

        public List<AltMutualFundSlice> getAssetList()
        {
            return assetList;
        }

        private static AltMutualFundSlice CopyAsset(AltMutualFundSlice asset)
        {
            return new AltMutualFundSlice { Name = asset.Name, Percentage = asset.Percentage, Rank = asset.Rank, Symbol = asset.Symbol };
        }

        public async Task<string> AddAssetAsync(AltMutualFundSlice fundSlice)
        {
            var retrunAsset = new AltMutualFundSlice { Name = fundSlice.Name, Percentage = fundSlice.Percentage, Rank = fundSlice.Rank, Symbol = fundSlice.Symbol };
            return await Task.FromResult(retrunAsset.Name);

        }

        public Task<AltMutualFundSlice> GetAssetAsync(string rank)
        {
            throw new NotImplementedException();
        }

      

        public Task<IList<string>> GetAssetAsync()
        {
            throw new NotImplementedException();
        }
    }
}

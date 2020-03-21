using System;
using System.Collections.Generic;
using MFContrast.Services.CsvConversionPath;

namespace MFContrast.Models.AlternativeMutualFundModels
{
    public class AlternativeMutualFundWhole
    {
        public string FundName { get; set; }
        public List<AltMutualFundSlice> AssetList { get; set; }
        public string Id { get; set; }

        public AlternativeMutualFundWhole()
        {
            AssetDataStore tableData = new AssetDataStore();
            AssetList = tableData.getAssetList();
            
        }


    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models.AlternativeMutualFundModels;
using MFContrast.Services.CsvConversionPath;

namespace MFContrast.Services
{
    public class CalculatePostCompare : AssetDataStore, ICalculatePostCompare
    {
        public AlternativeMutualFundWhole Fund1;
        public AlternativeMutualFundWhole Fund2;
        public IList<AltMutualFundSlice> Assets1;
        public IList<AltMutualFundSlice> Assets2;
        public IList<string> Asset1Names;
        public IList<string> Asset2Names;


        // This should be a service that creates and sets properties for a PostCompare data model 
        public CalculatePostCompare(AlternativeMutualFundWhole fund1, AlternativeMutualFundWhole fund2)
        {
            Fund1 = fund1;
            Fund2 = fund2;
            Assets1 = fund1.AssetList;
            Assets2 = fund2.AssetList;
            // InitializeAssetNames();
        }
        
        public async Task<IList<string>> GetAssetNames(int switchCase)
        {
            switch (switchCase) {

                case 1:
                    var names = new List<string>();
                    foreach (var asset in Assets1)
                    {
                        names.Add(string.Copy(asset.Name));
                    }
                    return await Task.FromResult(names);
                case 2:
                    var names2 = new List<string>();
                    foreach (var asset in Assets2)
                    {
                        names2.Add(string.Copy(asset.Name));
                    }
                    return await Task.FromResult(names2);
                default:
                    Console.Write("Default Reached");
                    return await Task.FromResult(new List<string>());


            }
           
            
        }

        public async Task<IList<string>> CalculateOverlap()
        {
            IList<string> a1 = await GetAssetNames(1);
            IList<string> a2 = await GetAssetNames(2);

            List<string> returnAsset = new List<string>();

            foreach(var name in a1)
            {
                if (a2.Contains(name))
                {
                    returnAsset.Add(string.Copy(name));
                }
            }
            return await Task.FromResult(returnAsset);
        }


        public async Task<IList<string>> CalculateUniqueHoldings1()
        {
            var returnAsset = new List<string>();

            foreach (var name in Asset1Names)
            {
                if (!Asset2Names.Contains(name))
                {
                    returnAsset.Add(string.Copy(name));
                }
            }
            return await Task.FromResult(returnAsset);
        }

        public async Task<IList<string>> CalculateUniqueHoldings2()
        {
            var returnAsset = new List<string>();

            foreach (var name in Asset2Names)
            {
                if (!Asset1Names.Contains(name))
                {
                    returnAsset.Add(string.Copy(name));
                }
            }
            return await Task.FromResult(returnAsset);
        }

        public float Get1In2()
        {
            throw new NotImplementedException();
        }

        public float Get2In1()
        {
            throw new NotImplementedException();
        }

        public float GetOverlapByWeight()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetOverlapHoldingsNumber()
        {
            IList<string> Overlap = await CalculateOverlap();
            int OverlapNumber = Overlap.Count;
            return await Task.FromResult(OverlapNumber);
        }

        private static AltMutualFundSlice CopyAsset(AltMutualFundSlice asset)
        {
            return new AltMutualFundSlice { Name = asset.Name, Percentage = asset.Percentage, Rank = asset.Rank, Symbol = asset.Symbol };
        }
        private static string CopyName(AltMutualFundSlice asset)
        {
            return string.Copy(asset.Name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models.AlternativeMutualFundModels;

namespace MFContrast.Services
{
    public class CalculatePostCompare : ICalculatePostCompare
    {
        public AlternativeMutualFundWhole Fund1;
        public AlternativeMutualFundWhole Fund2;
        public IList<AltMutualFundSlice> Assets1;
        public IList<AltMutualFundSlice> Assets2;
        public IList<string> Asset1Names;
        public IList<string> Asset2Names;



        public CalculatePostCompare(AlternativeMutualFundWhole fund1, AlternativeMutualFundWhole fund2)
        {
            Fund1 = fund1;
            Fund2 = fund2;
            Assets1 = fund1.AssetList;
            Assets2 = fund2.AssetList;
            InitializeAssetNames();
        }

        public void InitializeAssetNames()
        {
            foreach(var asset in Assets1)
            {
                Asset1Names.Add(asset.Name);
            }
            foreach(var asset in Assets2)
            {
                Asset2Names.Add(asset.Name);
            }
        }

        public async Task<IList<string>> CalculateOverlap()
        {
            var returnAsset = new List<string>();

            foreach(var name in Asset1Names)
            {
                if (Asset2Names.Contains(name))
                {
                    returnAsset.Add(name);
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
                    returnAsset.Add(name);
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
                    returnAsset.Add(name);
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
    }
}

using System;
using System.Collections.Generic;
using MFContrast.Models.AlternativeMutualFundModels;

namespace MFContrast.Models
{
    public class PostCompareModel
    {
        // Funds Selected
        public readonly AlternativeMutualFundWhole Fund1;
        public readonly AlternativeMutualFundWhole Fund2;

        // Overlapping assets
        public IList<AltMutualFundSlice> OverlappingHoldings { get; set; }
        // Number of Overlapping assets
        public int OverlappingHoldingsNumber { get; set; }

        // Assets unique to each fund
        public IList<AltMutualFundSlice> Fund1UniqueHoldings { get; set; }
        public IList<AltMutualFundSlice> Fund2UniqueHoldings { get; set; }

        // Overlap Percentage incorporating assets weight in each fund
        public float OverlapByWeight { get; set; }

        // Percent of Fund in other Fund
        public float Fund1InFund2Percent { get; set; }
        public float Fund2InFund1Percent { get; set; }



        public PostCompareModel(AlternativeMutualFundWhole fund1, AlternativeMutualFundWhole fund2)
        {
            Fund1 = fund1;
            Fund2 = fund2;
        }
    }
}

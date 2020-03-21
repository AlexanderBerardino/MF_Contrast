using System;
using System.Collections.Generic;
using MFContrast.Models.AlternativeMutualFundModels;

namespace MFContrast.Models
{
    public class PostCompareModel
    {
        // Funds Selected
        public AlternativeMutualFundWhole Fund1;
        public AlternativeMutualFundWhole Fund2;

        // Overlapping assets
        public readonly IList<AltMutualFundSlice> OverlappingHoldings;
        // Number of Overlapping assets
        public readonly int OverlappingHoldingsNumber;

        // Assets unique to each fund
        public readonly IList<AltMutualFundSlice> Fund1UniqueHoldings;
        public readonly IList<AltMutualFundSlice> Fund2UniqueHoldings;

        // Overlap Percentage incorporating assets weight in each fund
        public readonly float OverlapByWeight;

        // Percent of Fund in other Fund
        public readonly float Fund1InFund2Percent;
        public readonly float Fund2InFund1Percent;



        public PostCompareModel(AlternativeMutualFundWhole fund1, AlternativeMutualFundWhole fund2)
        {
            Fund1 = fund1;
            Fund2 = fund2;
        }
    }
}

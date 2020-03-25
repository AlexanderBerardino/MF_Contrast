using System.Collections.Generic;

namespace MFContrast.Models
{
    public class PostCompareModel
    {
        // Funds Selected
        public readonly MutualFund Fund1;
        public readonly MutualFund Fund2;

        // Holdings
        public IList<Holding> Holdings1 { get => Fund1.AssetList; }
        public IList<Holding> Holdings2 { get => Fund2.AssetList; }

        // Overlapping assets
        public IList<Holding> OverlappingHoldings { get; set; }

        // Number of Overlapping assets
        public int OverlappingHoldingsNumber { get; set; }

        // Assets unique to each fund
        public IList<Holding> Fund1UniqueHoldings { get; set; }
        public IList<Holding> Fund2UniqueHoldings { get; set; }

        // Overlap Percentage incorporating holdings weight in each fund
        public float OverlapByWeight { get; set; }

        // Percent of Fund in other Fund
        public float Fund1InFund2Percent { get; set; }
        public float Fund2InFund1Percent { get; set; }



        public PostCompareModel(MutualFund fund1, MutualFund fund2)
        {
            Fund1 = fund1;
            Fund2 = fund2;
            
        }
    }
}

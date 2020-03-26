using System.Collections.Generic;

namespace MFContrast.Models
{
    public class PostCompareModel
    {
        // Funds Selected
        public readonly MutualFund Fund1;
        public readonly MutualFund Fund2;


        public List<string> _Tickers1;
        public List<string> _Tickers2;

        public List<string> _OverlappingHoldings;


        // Holdings
        public List<Holding> Holdings1 => Fund1.AssetList;


        public List<Holding> Holdings2 => Fund2.AssetList;


        public List<string> Tickers1
        {
            get {
                var m = new List<string>();
                foreach (var fund in Holdings1)
                {
                        m.Add(string.Copy(fund.Name));
                }
                return m;
                }

        }


        public List<string> Tickers2
        {
            get => _Tickers2;
            set
            {
                foreach (var fund in Holdings2)
                {
                    _Tickers2.Add(string.Copy(fund.Name));
                }
            }
        }

        // Overlapping assets
        public List<string> OverlappingHoldings
        {
            get => _OverlappingHoldings;
            set
            {
                foreach (var ticker in _Tickers1)
                {
                    if (Tickers2.Contains(ticker))
                    {
                        _OverlappingHoldings.Add(string.Copy(ticker));
                    }
                }
            }
        }

        // Number of Overlapping assets
        public int OverlappingHoldingsNumber => _OverlappingHoldings.Count;

        // Assets unique to each fund
        public List<Holding> Fund1UniqueHoldings { get; set; }
        public List<Holding> Fund2UniqueHoldings { get; set; }

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

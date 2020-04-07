using System.Collections.Generic;
using System.Linq;
using MFContrast.Models;

namespace MFContrast.Services
{
    public class DictionaryBasedCompare : ListFundQuery<IList<Holding>, IEnumerable<Holding>>, ICompare
    {
        // Modify to private for release
        public List<Holding> S1 { get; set; }
        // Modify to private for release
        public List<Holding> S2 { get; set; }

        public List<Holding> S1Complement => DistillDifference(S2, S1).ToList();

        public List<Holding> S2Complement => DistillDifference(S1, S2).ToList();

        public List<string> S1UnionS2 => DistillUnion(S1, S2);

        public double F2InF1 => WeightedAverage(S1, S1UnionS2);
        public double F1InF2 => WeightedAverage(S2, S1UnionS2);

        public double OverlapPercentage => COP(F1InF2, F2InF1);

        public double F1TopTen => TopTen(S1);
        public double F2TopTen => TopTen(S2);

        public DictionaryBasedCompare(List<Holding> enumerableHoldings1, List<Holding> enumerableHoldings2)
        {
            // Cleaning Data
            S1 = RemoveNullHoldings(enumerableHoldings1).ToList();
            S2 = RemoveNullHoldings(enumerableHoldings2).ToList();
        }
    }
}

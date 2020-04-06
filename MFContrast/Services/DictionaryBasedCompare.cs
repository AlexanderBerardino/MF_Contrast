using System;
using System.Collections.Generic;
using System.Linq;
using MFContrast.Models;
namespace MFContrast.Services
{
    public class DictionaryBasedCompare
    {

        private List<Holding> S1 { get; set; }
        private List<Holding> S2 { get; set; }

        public List<Holding> S1Complement { get; set; }
        public List<Holding> S2Complement { get; set; }
        public List<string> S1UnionS2 { get; set; }

        public double F2InF1 { get; set; }
        public double F1InF2 { get; set; }
        public double OverlapPercentage => COP(F1InF2, F2InF1);

        public DictionaryBasedCompare(List<Holding> enumerableHoldings1, List<Holding> enumerableHoldings2)
        {
            S1 = RemoveNull(enumerableHoldings1);
            S2 = RemoveNull(enumerableHoldings2);
            S1Complement = DistillDifference(S2, S1);
            S2Complement = DistillDifference(S1, S2);
            S1UnionS2 = DistillUnion(S1, S2);
            F2InF1 = CalculateWeightedAverage(S1, S1UnionS2);
            F1InF2 = CalculateWeightedAverage(S2, S1UnionS2);
        }

        // Calculate Overlap Percentage
        private double COP(double x, double y) => (x + y) / 2;

        private static List<Holding> RemoveNull(List<Holding> holdings)
        {
            var query = from T1 in holdings
                        where !string.IsNullOrWhiteSpace(T1.Name)
                        where !string.IsNullOrWhiteSpace(T1.Symbol)
                        select T1;
            return query.ToList();
        }

        private static double CalculateWeightedAverage(List<Holding> d1, List<string> originolOtherList)
        {
            var query = from T1 in d1
                        join T2 in originolOtherList on T1.Symbol equals T2
                        select Convert.ToDouble(T1.Percentage);
            return query.Sum();
        }
     
        private static List<Holding> DistillDifference(List<Holding> targetList, List<Holding> exceptList)
        {
            var query = exceptList.Select(X => X.Name);
            var finalQuery = from T1 in targetList
                             where !(query.Contains(T1.Name))
                             select T1;
            return finalQuery.ToList();   
        }
       
        private static List<string> DistillUnion(List<Holding> targetList, List<Holding> exceptList)
        {
            var query = from T1 in targetList
                        join T2 in exceptList on T1.Symbol equals T2.Symbol
                        select T1.Symbol;
            return query.ToList();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using MFContrast.Models;
namespace MFContrast.Services
{
    public class DictionaryBasedCompare
    {
        // This class will eventually replace the List<string> Based Compare Class
        // The reason dictionary<string, double> works better is becuase many of
        // the displays couple the Ticker (string) and Percentage (double) in their presentation

        public Dictionary<string, double> s1 { get; set; }
        public Dictionary<string, double> s2 { get; set; }
        public Dictionary<string, double> s1Complement { get; set; }
        public Dictionary<string, double> s2Complement { get; set; }
        public Dictionary<string, double> s1Unions2 { get; set; }
        public double F2InF1 => CalculateWeightedAverage(s1, s2);
        public double F1InF2 => CalculateWeightedAverage(s2, s1);
        public double OverlapPercentage => CalculateOverlapPercentage(s1, s2, s1Unions2);

        public DictionaryBasedCompare(List<Holding> enumerableHoldings1, List<Holding> enumerableHoldings2)
        {
            s1 = TickerPercentageDictionary(enumerableHoldings1);
            s2 = TickerPercentageDictionary(enumerableHoldings2);
            s1Complement = DistillDifference(s2, s1);
            s2Complement = DistillDifference(s1, s2);
            s1Unions2 = DistillUnion(s1, s2);
        }

        public double CalculateOverlapPercentage(Dictionary<string, double> d1, Dictionary<string, double> d2, Dictionary<string, double> overlapHoldings)
        {
            double x = CalculateWeightedAverage(d1, overlapHoldings) + CalculateWeightedAverage(d2, overlapHoldings);
            return x / 2;
        }

        public static double CalculateWeightedAverage(Dictionary<string, double> targetFund, Dictionary<string, double> otherFund)
        {
            List<double> total = new List<double>();
            total.AddRange(from string name in otherFund
                           where targetFund.ContainsKey(name)
                           select targetFund[name]);
            return total.Sum();
        }
       

        public static Dictionary<string, double> TickerPercentageDictionary(List<Holding> enumerableHoldings)
        {
            return enumerableHoldings.ToDictionary(Holding => Holding.Symbol, Holding => Convert.ToDouble(Holding.Percentage));
        }

        private static Dictionary<string, double> DistillDifference(Dictionary<string, double> targetDict, Dictionary<string, double> exceptDict)
        {
            /*
            Dictionary<string, double> returnDictionary = new Dictionary<string, double>();
            foreach(KeyValuePair<string, double> keyValuePair in targetDict)
            {
                if (!ExceptDict.ContainsKey(keyValuePair.Key))
                {
                    returnDictionary.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }
            return returnDictionary;
            */
            return targetDict.Where(x => !exceptDict.ContainsKey(x.Key))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        private Dictionary<string, double> DistillUnion(Dictionary<string, double> primaryDict, Dictionary<string, double> secondaryDict)
        {
            return primaryDict.Where(x => secondaryDict.ContainsKey(x.Key))
                         .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using MFContrast.Models;

namespace MFContrast.Services
{
    public class Compare : ICompare
    {

        public Compare()
        {
        }

        public double CalculateOverlapPercentage(List<Holding> eh1, List<Holding> eh2, List<string> overlapHoldings)
        {
            double x = CalculateWeightedAverage(eh1, overlapHoldings) + CalculateWeightedAverage(eh2, overlapHoldings);
            return x / 2;
        }

        // Returns the total % of holdings of one Fund in the other by summing overlapping holding percentage
       
        public double CalculateWeightedAverage(List<Holding> targetFund, List<string> otherFund)
        {
            List<double> total = new List<double>();
            Dictionary<string, double> namePercentageDict = TickerPercentageDictionary(targetFund);
            total.AddRange(from string name in otherFund
                           where namePercentageDict.ContainsKey(name)
                           select namePercentageDict[name]);
            return total.Sum();
        }

        public List<string> DistillTickers(List<Holding> enumerableHoldings)
        {
            List<string> t1 = enumerableHoldings.Select(Holding => Holding.Symbol).ToList();
            return t1.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        }

        public Dictionary<string, double> TickerPercentageDictionary(List<Holding> enumerableHoldings)
        {
            return enumerableHoldings.ToDictionary(Holding => Holding.Symbol, Holding => Convert.ToDouble(Holding.Percentage));
        }

    }
}

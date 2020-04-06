using System;
using System.Collections.Generic;
using System.Linq;
using MFContrast.Models;

namespace MFContrast.Services
{
    public class Compare
    {
        
        public Compare()
        {
        }

        // returns 0.5 * ((Sum of overlappingHoldings in eh1) + (Sum of overlappingHoldings in eh2))
        public double CalculateOverlapPercentage(List<Holding>eh1, List<Holding>eh2, List<string> overlapHoldings)
        {
            double x = CalculateWeightedAverage(eh1, overlapHoldings) + CalculateWeightedAverage(eh2, overlapHoldings);
            return x / 2;
        }

        

        // Currently total percentage based on added percentages of top 100 funds
        // thereore comparing a mutual fund to itself will not yield 100% similarity 
        // Returns the total % of holdings of one Fund in the other by summing overlapping holding percentage
        public double CalculateWeightedAverage(List<Holding>targetFund, List<string> otherFund)
        {
            List<double> total = new List<double>();
            Dictionary<string, double> namePercentageDict = TickerPercentageDictionary(targetFund);
            total.AddRange(from string name in otherFund
                           where namePercentageDict.ContainsKey(name)
                           select namePercentageDict[name]);
            return total.Sum();
        }

      
        // Returns List of Symbol^ property from List of Holdings  ^(AKA Ticker, i.e Apple=>APPL)
        public List<string> DistillTickers(List<Holding>enumerableHoldings)
        {
            List<string> t1 = enumerableHoldings.Select(Holding => Holding.Symbol).ToList();
            return t1.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        }
        // Returns Dictionary of <Symbol, Percentage>, i.e  { Name="Apple", Percentage="2.1", Rank=2, Symbol="AAPL } => <"AAPL", 2.1>
        Dictionary<string, double> TickerPercentageDictionary(List<Holding>enumerableHoldings)
        {
            return enumerableHoldings.ToDictionary(Holding => Holding.Symbol, Holding => Convert.ToDouble(Holding.Percentage));
        }

      
    }
}

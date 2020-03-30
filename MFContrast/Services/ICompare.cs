using System;
using System.Collections.Generic;
using MFContrast.Models;

namespace MFContrast.Services
{
    public interface ICompare
    {
        Dictionary<string, double> TickerPercentageDictionary(List<Holding> enumerableHoldings);
        List<string> DistillTickers(List<Holding> enumerableHoldings);
        double CalculateWeightedAverage(List<Holding> enumerableHoldings, List<string> uniqueHoldings);
        double CalculateOverlapPercentage(List<Holding> uniqueHoldings1, List<Holding> uniqueHoldings2, List<string> overlapHoldings);
    }
}

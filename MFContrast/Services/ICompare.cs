using System;
using System.Collections.Generic;
using System.Linq;
using MFContrast.Models;

namespace MFContrast.Services
{
    //public interface ICompare<T, K>
    ////where T : IEnumerable<Tuple<T>>
    //where K : IEnumerable<Holding>
    //{
    //    T TickerPercentageDictionary(K enumerableHoldings);
    //    // T DistillTickers(K enumerableHoldings);
    //    double CalculateWeightedAverage(K enumerableHoldings, K uniqueHoldings);
    //    double CalculateOverlapPercentage(K uniqueHoldings1, K uniqueHoldings2, K overlapHoldings);
    //}

    public interface ICompare
    {
        Dictionary<string, double> TickerPercentageDictionary(IEnumerable<Holding> enumerableHoldings);
        List<string> DistillTickers(List<Holding> enumerableHoldings);
        double CalculateWeightedAverage(IEnumerable<Holding> enumerableHoldings, IEnumerable<Holding> uniqueHoldings);
        double CalculateOverlapPercentage(IEnumerable<Holding> uniqueHoldings1, IEnumerable<Holding> uniqueHoldings2, IEnumerable<Holding> overlapHoldings);
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using MFContrast.Models;

namespace MFContrast.Services
{
    // Convert to Strategy
    public interface IFundQuery<T, H>
    {
        H RemoveNullHoldings(T holdings);
        List<string> DistillUnion(T target, T except);
        H DistillDifference(T target, T except);
        double TopTen(T target);
        double WeightedAverage(T target, List<string> union);
        double COP(double x, double y);
    }

    public class ListFundQuery<T, H> : IFundQuery<T, H>
        where T: IList<Holding>
        where H: IEnumerable<Holding>
    {
        // Calculate Overlap Percentage
        public double COP(double x, double y) => (x + y) / 2;

        // Remove Holdings With Empty String or null For Symbol or Name
        public H RemoveNullHoldings(T holdings)
        {
            var query = from T1 in holdings
                        where !string.IsNullOrWhiteSpace(T1.Name)
                        where !string.IsNullOrWhiteSpace(T1.Symbol)
                        select T1;
            return (H)query;
        }

        // Currently total percentage based on added percentages of top 100 funds
        // therefore comparing a mutual fund to itself will not yield 100% similarity 
        // Returns the total % of holdings of one Fund in the other by summing overlapping holding percentage
        public double WeightedAverage(T d1, List<string> originolOtherList)
        {
            var query = from T1 in d1
                        join T2 in originolOtherList on T1.Symbol equals T2
                        select Convert.ToDouble(T1.Percentage);
            return query.Sum();
        }

        public H DistillDifference(T targetList, T exceptList)
        {
            var query = exceptList.Select(X => X.Name);
            var finalQuery = from T1 in targetList
                             where !(query.Contains(T1.Name))
                             select T1;
            return (H)finalQuery;
        }

        public List<string> DistillUnion(T targetList, T exceptList)
        {
            var query = from T1 in targetList
                        join T2 in exceptList on T1.Symbol equals T2.Symbol
                        select T1.Symbol;
            return query.ToList();
        }

        // Return sum of first ten holdings percentages 
        public double TopTen(T targetList)
        {
            return targetList.Select(x => Convert.ToDouble(x.Percentage)).Take(10).Sum();
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using MFContrast.Models;

namespace MFContrast.ViewModels
{
    public class PostCompareOverlapViewModel : BaseViewModel
    {

        private MutualFund F1;
        private MutualFund F2;
        private List<string> unique1;
        private List<string> unique2;
        private List<string> overlapList;

        public MutualFund Fund1
        {
            get { return F1; }
            set { F1 = value; }
        }
        public MutualFund Fund2
        {
            get { return F2; }
            set { F2 = value; }
        }
        
        public List<string> Unique1
        {
            get { return unique1; }
            set { unique1 = value; }
        }
        public List<string> Unique2
        {
            get { return unique2; }
            set { unique2 = value; }
        }
        
        public List<string> OverlapList
        {
            get { return overlapList; }
            set { overlapList = value; }
        }
        
        public List<Holding> Holdings1 => Fund1.AssetList;
        public List<Holding> Holdings2 => Fund2.AssetList;
        public int OverlapListSize => OverlapList.Count;
        public int U1Size => Unique1.Count;
        public int U2Size => Unique2.Count;
        public double F2InF1 => CalcWeightedAverage(Holdings1, DistillTickers2());
        public double F1InF2 => CalcWeightedAverage(Holdings2, DistillTickers1());
        public double OverlapPercentage => CalcOverlapPercentage(Holdings1, Holdings2, OverlapList);
        

        public PostCompareOverlapViewModel(MutualFund f1, MutualFund f2)

        {
            Fund1 = f1;
            Fund2 = f2;
         
            OverlapList = DistillTickers1().Intersect(DistillTickers2()).ToList();
            Unique1 = DistillTickers1().Except(DistillTickers2()).ToList();
            Unique2 = DistillTickers2().Except(DistillTickers1()).ToList();      
        }
        private List<string> DistillTickers1()
        {
            List<string> t1 = Holdings1.Select(Holding => Holding.Symbol).ToList();
            return t1.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        }
        private List<string> DistillTickers2()
        {
            List<string> t2 = Holdings2.Select(Holding => Holding.Symbol).ToList();
            return t2.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        }

        // Returns the total % of holdings of one Fund in the other by summing overlapping holding percentage
        private double CalcWeightedAverage(List<Holding> enumerableHoldings, List<string> hasHolding)
        {
            List<double> total = new List<double>();
            Dictionary<string, double> namePercentageDict =
                enumerableHoldings.ToDictionary(Holding => Holding.Symbol, Holding => Convert.ToDouble(Holding.Percentage));
            foreach(string name in hasHolding)
            {
                if (namePercentageDict.ContainsKey(name))
                { 
                    total.Add(namePercentageDict[name]);
                }
            }
            return total.Sum();
        }

        private double CalcOverlapPercentage(List<Holding> eh1, List<Holding> eh2, List<string> overlap)
        {
            double x = CalcWeightedAverage(eh1, overlap) + CalcWeightedAverage(eh2, overlap);
            return x / 2;
        }
    }
}

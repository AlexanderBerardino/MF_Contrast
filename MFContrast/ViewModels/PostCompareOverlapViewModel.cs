﻿using System;
using System.Linq;
using System.Collections.Generic;
using MFContrast.Models;
using MFContrast.Services;

namespace MFContrast.ViewModels
{
    public class PostCompareOverlapViewModel : BaseViewModel
    {
        
        private MutualFund F1;
        private MutualFund F2;
        private List<string> unique1;
        private List<string> unique2;
        private List<string> overlapList;

        // This can later be set through composition or inherited depending on use
        public ICompare C { get; set; }
        
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


        public double F2InF1 => PercentFundZInTargetFund(targetFund: Holdings1, FundZ: Holdings2);
        public double F1InF2 => PercentFundZInTargetFund(targetFund: Holdings2, FundZ: Holdings1);

        public double OverlapPercentage => GetOverlapPercentage(Holdings1, Holdings2, OverlapList);
        

        public PostCompareOverlapViewModel(MutualFund f1, MutualFund f2)

        {
            Fund1 = f1;
            Fund2 = f2;
            C = new Compare();

            // Unique 1 Union Unique 2 
            OverlapList = DistillUnion(Holdings1, Holdings2);

            // Unique 1 Intersection Unique 2
            Unique1 = DistillDifference(Holdings1, Holdings2);

            // Unique 2 Intersection Unique 1
            Unique2 = DistillDifference(Holdings2, Holdings1);
            
        }


        private List<string> DistillDifference(List<Holding> targetList, List<Holding> exceptList)
        {
            return C.DistillTickers(targetList).Except(C.DistillTickers(exceptList)).ToList();
        }

        private List<string> DistillUnion(List<Holding> listOne, List<Holding> listTwo)
        {
            return C.DistillTickers(listOne).Intersect(C.DistillTickers(listTwo)).ToList();
        }

        // Returns what percentage of targetFund is composed of holdings found in FundZ 
        private double PercentFundZInTargetFund(List<Holding> targetFund, List<Holding> FundZ)
        {
            return C.CalculateWeightedAverage(targetFund, C.DistillTickers(FundZ));
        }

        private double GetOverlapPercentage(List<Holding> one, List<Holding> two, List<string> overlapList)
        {
            return C.CalculateOverlapPercentage(one, two, overlapList);
        }
    }
}

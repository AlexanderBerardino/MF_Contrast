using System.Collections.Generic;
using MFContrast.Models;
using MFContrast.Services;

namespace MFContrast.ViewModels
{
    public class PostCompareOverlapViewModelV2 : BaseViewModel
    {
        // This will be turned into the base of the carousel view
        private MutualFund F1;
        private MutualFund F2;

        private List<Holding> unique1;
        private List<Holding> unique2;
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

        public List<Holding> Unique1
        {
            get { return unique1; }
            set { unique1 = value; }
        }
        public List<Holding> Unique2
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
        public double F2InF1 => C.F2InF1;
        public double F1InF2 => C.F1InF2;
        public double OverlapPercentage => C.OverlapPercentage;
        public double F1TopTen => C.F1TopTen;
        public double F2TopTen => C.F2TopTen;

        public PostCompareOverlapViewModelV2(MutualFund f1, MutualFund f2)
        {
            Fund1 = f1;
            Fund2 = f2;
            C = new ListBasedCompare(Holdings1, Holdings2);
            Unique1 = C.S2Complement;
            Unique2 = C.S1Complement;
            OverlapList = C.S1UnionS2;
        }
    }
}

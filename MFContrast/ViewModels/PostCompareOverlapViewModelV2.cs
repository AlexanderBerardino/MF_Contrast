using System;
using System.Collections.Generic;
using MFContrast.Models;
using MFContrast.Services;

namespace MFContrast.ViewModels
{
    public class PostCompareOverlapViewModelV2 : BaseViewModel
    {

        // This can later be set through composition or inherited depending on use
        public ICompare C { get; set; }

        public MutualFund Fund1 { get; set; }
        public MutualFund Fund2 { get; set; }
        public List<Holding> Unique1 { get; set; }
        public List<Holding> Unique2 { get; set; }
        public List<string> OverlapList { get; set; }

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
        public int ListMaxRow => MaxOfThree(OverlapListSize, U1Size, U2Size);


        public PostCompareOverlapViewModelV2(MutualFund f1, MutualFund f2)
        {
            Fund1 = f1;
            Fund2 = f2;
            C = new ListBasedCompare(Holdings1, Holdings2);
            Unique1 = C.S2Complement;
            Unique2 = C.S1Complement;
            OverlapList = C.S1UnionS2;
        }

        private int MaxOfThree(int OverlapSize, int L2Count, int L3Count)
        {
            if(OverlapSize == 0)
            {
                return Math.Max(L2Count, L3Count);
            }
            else
            {
                return Math.Max(OverlapSize, Math.Max(L2Count, L3Count));
            }
        }
    }

    public class PostCompareOverlapViewModelSpecific : PostCompareOverlapViewModelV2
    {
        public string UpperTicker1 => Fund1.Ticker.ToUpper();
        public string UpperTicker2 => Fund2.Ticker.ToUpper();
        public string[] PCOLVItemsSource { get; set; }
        public string HGL1 { get; set; }
        public string HGL2 { get; set; }
        public string HGL3 { get; set; }

        public PostCompareOverlapViewModelSpecific(MutualFund f1, MutualFund f2) : base(f1, f2)
        {
            PCOLVItemsSource = new string[]
            {
                    string.Join(" ","Overlap Size:", OverlapListSize.ToString()),
                    string.Join(" ", UpperTicker1, "# of Unique Holdings:", U1Size.ToString()),
                    string.Join(" ", UpperTicker2, "# of Unique Holdings:", U2Size.ToString()),
                    string.Join(" ", UpperTicker2, "in", UpperTicker1+":", string.Format("{0:0.#####}", F2InF1), "%"),
                    string.Join(" ", UpperTicker1, "in", UpperTicker2+":", string.Format("{0:0.#####}", F1InF2), "%"),
                    string.Join(" ", "Overlap By Weight:", string.Format("{0:0.#####}", OverlapPercentage), "%"),
                    string.Join(" ", UpperTicker1, "Top Ten:", string.Format("{0:0.#####}", F1TopTen), "%"),
                    string.Join(" ", UpperTicker2, "Top Ten:", string.Format("{0:0.#####}", F2TopTen), "%"),
            };

            HGL1 = "Overlap";
            HGL2 = HGFormatter(UpperTicker1);
            HGL3 = HGFormatter(UpperTicker2);
        }

        private string HGFormatter(string formatee)
        {
            return string.Join(separator: " ", formatee, "Unique");
        }
    }
}

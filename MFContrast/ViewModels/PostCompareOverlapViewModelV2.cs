using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MFContrast.Models;
using MFContrast.Services;

namespace MFContrast.ViewModels
{
    public class PostCompareOverlapViewModelV2 : BaseViewModel
    {
        // Interface for comparison calculations
        public ICompare C { get; set; }

        // Fund1, Fund2 objects
        public MutualFund Fund1 { get; set; }
        public MutualFund Fund2 { get; set; }

        // Unique Holdings in Fund1, Fund2
        public List<Holding> Unique1 { get; set; }
        public List<Holding> Unique2 { get; set; }

        // Holdings Overlapping from Fund1, Fund2
        public List<string> OverlapList { get; set; }

        // Get Fund1, Fund2 AssetList(List<Holding>)
        public List<Holding> Holdings1 => Fund1.AssetList;
        public List<Holding> Holdings2 => Fund2.AssetList;

        // Size of List Above
        public int OverlapListSize => OverlapList.Count;
        public int U1Size => Unique1.Count;
        public int U2Size => Unique2.Count;

        // % of FundX in FundY
        public double F2InF1 => C.F2InF1;
        public double F1InF2 => C.F1InF2;

        // % Similarity between Fund1, Fund2
        public double OverlapPercentage => C.OverlapPercentage;
        public double F1TopTen => C.F1TopTen;
        public double F2TopTen => C.F2TopTen;

        // Largest Container of Funds (Used for choosing grid row number)
        public int ListMaxRow => MaxOfThree(OverlapListSize, U1Size, U2Size);

        // Returns uppercase ticker
        public string UpperTicker1 => Fund1.Ticker.ToUpper();
        public string UpperTicker2 => Fund2.Ticker.ToUpper();


        public PostCompareOverlapViewModelV2(MutualFund f1, MutualFund f2)
        {
            Fund1 = f1;
            Fund2 = f2;
            C = new ListBasedCompare(Holdings1, Holdings2);
            Unique1 = C.S2Complement;
            Unique2 = C.S1Complement;
            OverlapList = C.S1UnionS2;
        }

        // Returns largest of three integer inputs
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

    // ViewModel for Statistic Page
    public class PostCompareOverlapStatisticalViewModel : PostCompareOverlapViewModelV2
    {
        // Collection of StatModels
        public ObservableCollection<GroupedStatModel> StatsGrouped { get; set; }

        public PostCompareOverlapStatisticalViewModel(MutualFund f1, MutualFund f2) : base(f1, f2)
        {
            StatsGrouped = new ObservableCollection<GroupedStatModel>();
            GroupedStatModel holdingsNumberGroup = new GroupedStatModel() { GroupStatTitle = "Number of Holdings" };
            GroupedStatModel percentXInYGroup = new GroupedStatModel() { GroupStatTitle = "Percent X In Y" };
            GroupedStatModel topTenGroup = new GroupedStatModel() { GroupStatTitle = "Top Ten Holdings" };

            holdingsNumberGroup.Add(new StatModel()
            {
                StatTitle = "# of Overlapping Holdings",
                StatValue = OverlapListSize.ToString()
            });
            holdingsNumberGroup.Add(new StatModel()
            {
                StatTitle = string.Join(" ", UpperTicker1, "# of Unique Holdings"),
                StatValue = U1Size.ToString()
            });
            holdingsNumberGroup.Add(new StatModel()
            {
                StatTitle = string.Join(" ", UpperTicker2, "# of Unique Holdings"),
                StatValue = U2Size.ToString()
            });
            percentXInYGroup.Add(new StatModel()
            {
                StatTitle = string.Join(" ", UpperTicker2, "in", UpperTicker1),
                StatValue = string.Format("{0:0.#####}", F2InF1)
            });
            percentXInYGroup.Add(new StatModel()
            {
                StatTitle = string.Join(" ", UpperTicker1, "in", UpperTicker2),
                StatValue = string.Format("{0:0.#####}", F1InF2)
            });
           
            topTenGroup.Add(new StatModel()
            {
                StatTitle = string.Join(" ", UpperTicker1, "Top Ten %"),
                StatValue = string.Format("{0:0.#####}", F1TopTen)
            });
            topTenGroup.Add(new StatModel()
            {
                StatTitle = string.Join(" ", UpperTicker2, "Top Ten %"),
                StatValue = string.Format("{0:0.#####}", F2TopTen)
            });

            StatsGrouped.Add(holdingsNumberGroup);
            StatsGrouped.Add(percentXInYGroup);
            StatsGrouped.Add(topTenGroup);
        }
    }

    // ViewModel for Grid Page
    public class PostCompareOverlapGridViewModel : PostCompareOverlapViewModelV2
    {
        // HGL = Header Grid Label 
        public string HGL1 { get; set; }
        public string HGL2 { get; set; }
        public string HGL3 { get; set; }

        public PostCompareOverlapGridViewModel(MutualFund f1, MutualFund f2) : base(f1, f2)
        {
            HGL1 = "Overlap";
            HGL2 = HGFormatter(UpperTicker1);
            HGL3 = HGFormatter(UpperTicker2);
        }

        // Returns formatted column header string 
        private string HGFormatter(string formatee)
        {
            return string.Join(separator: " ", formatee, "Unique");
        }
    }
}

using Xunit;
using MFContrast.Models;
using MFContrast.Services;

namespace MFUnitTests
{
    public class PostCompareUnitTest
    {
        public MutualFund MockFundOne { get; set; }
        public MutualFund MockFundTwo { get; set; }
        public DictionaryBasedCompare Comparer {get; set;}
        // public PostCompareOverlapViewModelV2 ViewModel { get; set; }

        public PostCompareUnitTest()
        {
            MockFundOne = new MutualFund("vfiax")
            {
                Id = "0",
                FundName = "Vanguard",
                // Ticker = "vfiax",
            };

            MockFundTwo = new MutualFund("fcntx")
            {
                Id = "1",
                FundName = "Fidelity",
                // Ticker = "fcntx"
            };

            Comparer = new DictionaryBasedCompare(MockFundOne.AssetList, MockFundTwo.AssetList);
            // ViewModel = new PostCompareOverlapViewModelV2(MockFundOne, MockFundTwo);
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(22.25, Comparer.F1TopTen, 3);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(43.05, Comparer.F2TopTen, 3);
        }
    }
}

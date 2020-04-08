using Xunit;
using MFContrast.Models;
using System;

namespace MFUnitTests
{
    public class UnitTest1
    {
        public MutualFund MockFund { get; set; }

        public UnitTest1()
        {
            MockFund = new MutualFund("vfiax")
            {
                Id = "0",
                FundName = "Vanguard",
            };
        }

        [Fact]
        public void Test1()
        {
            Assert.True(MockFund.AssetList.Count == 99);
        }

        [Fact]
        public void Test2()
        {
            Assert.True(Convert.ToDouble(MockFund.Id) == 0.0);
        }

        [Fact]
        public void Test3()
        {
            Holding firstHolding = MockFund.AssetList[0];
            Assert.Contains("MICROSOFT", firstHolding.Name);
        }
    }

    public class MockFunds
    {
        public MutualFund MockFund1 { get; set; }
        public MutualFund MockFund2 { get; set; }

        public MockFunds()
        {
            MockFund1 = new MutualFund("vfiax")
            {
                Id = "0",
                FundName = "Vanguard",
            };
            MockFund2 = new MutualFund("fcntx")
            {
                Id = "1",
                FundName = "Fidelity",
            };
        }
    }
}

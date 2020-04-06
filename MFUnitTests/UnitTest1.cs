using Xunit;
using MFContrast.Models;

namespace MFUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            MutualFund m1 = new MutualFund("vfiax")
            {
                Id = "0",
                FundName = "Vanguard",
                // Ticker = "vfiax",

            };
            MutualFund m2 = new MutualFund("fcntx")
            {
                Id = "1",
                FundName = "Fidelity",
                // Ticker = "fcntx"
            };
        }
    }
}

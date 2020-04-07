using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFContrast.Models;

namespace MFContrast.Services
{
    public class MutualFundDataStore : IMutualFundDataStore
    {

        private static readonly List<MutualFund> FundList;
        private static int nextFundId;

        static MutualFundDataStore()
        {
            FundList = new List<MutualFund> {

                new MutualFund("vfiax") {
                    Id = "0",
                    FundName = "Vanguard",
                    // Ticker = "vfiax",

                },
                new MutualFund("fcntx") {
                    Id = "1",
                    FundName = "Fidelity",
                    // Ticker = "fcntx"
                },

                new MutualFund("vsmax")
                {
                    Id="2",
                    FundName="Vanguard Small Cap"
                }
            };
            nextFundId = FundList.Count;
        }

        public async Task<string> AddItemAsync(MutualFund fund)
        {
            lock (this)
            {
                fund.Id = nextFundId.ToString();
                FundList.Add(fund);
                nextFundId++;
            }
            return await Task.FromResult(fund.Id);
        }

        public async Task<IList<MutualFund>> GetItemsAsync()
        {
            List<MutualFund> returnFunds = new List<MutualFund>();
            foreach (var fund in FundList)
            {
                returnFunds.Add(CopyFund(fund));
            }
            return await Task.FromResult(returnFunds);
        }

        private static MutualFund CopyFund(MutualFund fund)
        {
            // return new MutualFund { FundName = fund.FundName, Id = fund.Id, Ticker = fund.Ticker };
            return new MutualFund(fund.Ticker) { FundName = fund.FundName, Id = fund.Id };
        }

        public async Task<MutualFund> GetItemAsync(string id)
        {
            MutualFund fund = FundList.FirstOrDefault(Fund => Fund.Id == id);

            MutualFund returnFund = CopyFund(fund);
            return await Task.FromResult(returnFund);
        }
    }
}

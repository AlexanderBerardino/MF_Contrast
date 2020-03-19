using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFContrast.Models.AlternativeMutualFundModels;

namespace MFContrast.Services
{
    public class MutualFundDataStore : IMutualFundDataStore
    {
        private static readonly List<AlternativeMutualFundWhole> FundList;
        private static int nextFundId;

        static MutualFundDataStore()
        {
            FundList = new List<AlternativeMutualFundWhole> {

            new AlternativeMutualFundWhole { Id = "0", FundName = "Vanguard" },
            new AlternativeMutualFundWhole { Id = "1", FundName = "Vanguard" },
            new AlternativeMutualFundWhole { Id = "2", FundName = "Vanguard" },
            new AlternativeMutualFundWhole { Id = "3", FundName = "Vanguard" },
            };

            nextFundId = FundList.Count;
        }

        public async Task<string> AddItemAsync(AlternativeMutualFundWhole fund)
        {
            lock (this)
            {
                fund.Id = nextFundId.ToString();
                FundList.Add(fund);
                nextFundId++;
            }
            return await Task.FromResult(fund.Id);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }


        public async Task<IList<AlternativeMutualFundWhole>> GetItemsAsync()
        {
            var returnFunds = new List<AlternativeMutualFundWhole>();
            foreach (var fund in FundList)
            {
                returnFunds.Add(CopyFund(fund));
            }
            return await Task.FromResult(returnFunds);
        }

        private static AlternativeMutualFundWhole CopyFund(AlternativeMutualFundWhole fund)
        {
            return new AlternativeMutualFundWhole { FundName = fund.FundName, Id = fund.Id };
        }

        public async Task<bool> UpdateItemAsync(AlternativeMutualFundWhole fund)
        {
            var fundIndex = FundList.FindIndex((AlternativeMutualFundWhole arg) => arg.Id == fund.Id);
            var fundFound = fundIndex != -1;
            if (fundFound)
            {
                FundList[fundIndex].FundName = fund.FundName;
                FundList[fundIndex].Id = fund.Id;
            }
            return await Task.FromResult(fundFound);
        }

        public async Task<AlternativeMutualFundWhole> GetItemAsync(string id)
        {
            var fund = FundList.FirstOrDefault(courseNote => courseNote.Id == id);

            var returnFund = CopyFund(fund);
            return await Task.FromResult(returnFund);
        }
    }

   
}

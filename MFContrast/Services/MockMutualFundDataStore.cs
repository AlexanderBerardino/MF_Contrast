using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFContrast.Models;

namespace MFContrast.Services
{
    public class MockMutualFundDataStore : IMutualFundDataStore
    {
        private static readonly List<string> mockMutualFundNames;
        private static readonly List<MutualFundSlice> mockMutualFundSlices;
        private static int nextMutualFundSliceId;

        static MockMutualFundDataStore()
        {
            mockMutualFundNames = new List<string>
            {
                "Microsoft Corp",
                "Apple Inc",
                "Amazon.com Inc",
                "Facebook Inc A",
                "Alphabet Inc Class C",
                "Alphabet Inc A",
                "Berkshire Hathaway Inc B",
                "JPMorgan Chase & Co",
                "Johnson & Johnson",
                "Visa Inc Class A",
            };

            mockMutualFundSlices = new List<MutualFundSlice>
            {
                new MutualFundSlice
                {
                     name="Microsoft Corp",
                     symbol= "MSFT",
                     url= "https://finance.yahoo.com/quote/MSFT?p=MSFT",
                     Assets= 4.81,
                     Id="0"
                },
                 new MutualFundSlice
                {
                     name="Apple Inc",
                     symbol= "APPL",
                     url= "https://finance.yahoo.com/quote/AAPL?p=AAPL",
                     Assets= 4.79,
                     Id="1"
                },
                  new MutualFundSlice
                {
                     name="Amazon.com Inc",
                     symbol= "AMZN",
                     url= "https://finance.yahoo.com/quote/AMZN?p=AMZN",
                     Assets= 3.10,
                     Id="2"
                },
                   new MutualFundSlice
                {
                     name="Facebook Inc A",
                     symbol= "FB",
                     url= "https://finance.yahoo.com/quote/FB?p=FB",
                     Assets= 1.80,
                     Id="3"
                },
                    new MutualFundSlice
                {
                     name="Alphabet Inc Class C",
                     symbol= "GOOG",
                     url= "https://finance.yahoo.com/quote/GOOG?p=GOOG",
                     Assets= 1.59,
                     Id="4"
                },
                 new MutualFundSlice
                 {
                    name= "Alphabet Inc A",
                    symbol= "GOOGL",
                    url= "https://finance.yahoo.com/quote/GOOGL?p=GOOGL",
                    Assets= 1.58,
                    Id="5"
                 },
                 new MutualFundSlice
                 {

                    name= "Berkshire Hathaway Inc B",
                    symbol= "BRK.B",
                    url= "https://finance.yahoo.com/quote/BRK.B?p=BRK.B",
                    Assets= 1.58,
                    Id="6"
                },
                 new MutualFundSlice
                 {
                    name= "JPMorgan Chase & Co",
                    symbol= "JPM",
                    url= "https://finance.yahoo.com/quote/JPM?p=JPM",
                    Assets= 1.54,
                    Id="7"
                 },
                 new MutualFundSlice
                 {
                      name= "Johnson & Johnson",
                      symbol= "JNJ",
                      url= "https://finance.yahoo.com/quote/JNJ?p=JNJ",
                      Assets= 1.45,
                      Id="8"
                 },
                 new MutualFundSlice
                 {
                      name= "Visa Inc Class A",
                      symbol= "V",
                      url= "https://finance.yahoo.com/quote/V?p=V",
                      Assets= 1.26,
                      Id="9"
                 }

            };

            nextMutualFundSliceId = mockMutualFundSlices.Count;

        }

        public async Task<string> AddMutualFundSliceAsync(MutualFundSlice myFund)
        {
            lock (this)
            {
                myFund.Id = nextMutualFundSliceId.ToString();
                mockMutualFundSlices.Add(myFund);
                nextMutualFundSliceId++;
            }
            return await Task.FromResult(myFund.Id);
        }
        private static MutualFundSlice CopyFund(MutualFundSlice fund)
        {
            return new MutualFundSlice { Id = fund.Id,
                                         name = fund.name,
                                         symbol = fund.symbol,
                                         url = fund.url,
                                         Assets = fund.Assets };
        }

        public async Task<IList<MutualFundSlice>> GetMutualFundSlicesAsync()
        {
            var returnFunds = new List<MutualFundSlice>();
            foreach (var fund in mockMutualFundSlices)
                returnFunds.Add(CopyFund(fund));
            return await Task.FromResult(returnFunds);
        }
        /*
        public Task<IList<MutualFund>> GetFundAsync(string id)
        {
            var fund = mockMutualFunds.FirstOrDefault(m => courseNote.Id == id);

            // Make a copy of the note to simulate reading from an external datastore
            var returnNote = CopyNote(note);
            return await Task.FromResult(returnNote);
        }
        */

        public async Task<bool> UpdateMutualFundSlicesAsync(MutualFundSlice myFund)
        {
            var fundIndex = mockMutualFundSlices.FindIndex((MutualFundSlice arg) => arg.Id == myFund.Id);
            var fundFound = fundIndex != -1;
            if (fundFound)
            {
                mockMutualFundSlices[fundIndex].name = myFund.name;
                mockMutualFundSlices[fundIndex].symbol = myFund.symbol;
                mockMutualFundSlices[fundIndex].url = myFund.url;
                mockMutualFundSlices[fundIndex].Assets = myFund.Assets;
            }
            return await Task.FromResult(fundFound);
        }

        public async Task<IList<string>> GetMutualFundSliceNamesAsync()
        {
            return await Task.FromResult(mockMutualFundNames);
        }
    }
}


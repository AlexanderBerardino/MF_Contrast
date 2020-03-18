using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models;

namespace MFContrast.Services
{
    public class MockMutualFundDataStore
    {
        private static readonly List<string> mockMutualFundNames;
        private static readonly List<MutualFundSlice> VFIAX_list;
        private static readonly MutualFundWhole FFIDX;
        private static readonly MutualFundWhole VVFIAX;
        private static readonly List<MutualFundSlice> FFIDX_list;
        private static readonly List<MutualFundWhole> FundList;
        private static int nextMutualFundSliceId;
        private static int nextMutualFundWholeId;

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

            FFIDX_list = new List<MutualFundSlice>
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
   

            VFIAX_list = new List<MutualFundSlice>
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

            // VVFIAX = new MutualFundWhole("VVFIAX", VFIAX_list);
            FundList = new List<MutualFundWhole>();
            FundList.Add(VVFIAX);
            FundList.Add(FFIDX);
            nextMutualFundSliceId = VFIAX_list.Count;
            nextMutualFundWholeId = FundList.Count;


        }



        public async Task<string> AddMutualFundSliceAsync(MutualFundSlice fundSlice)
        {
            lock (this)
            {
                fundSlice.Id = nextMutualFundSliceId.ToString();
                VFIAX_list.Add(fundSlice);
                nextMutualFundSliceId++;
            }
            return await Task.FromResult(fundSlice.Id);
        }

        private static MutualFundSlice CopyFund(MutualFundSlice fundSlice)
        {
            return new MutualFundSlice { Id = fundSlice.Id,
                                         name = fundSlice.name,
                                         symbol = fundSlice.symbol,
                                         url = fundSlice.url,
                                         Assets = fundSlice.Assets };
        }

        public async Task<IList<MutualFundSlice>> GetMutualFundSlicesAsync()
        {
            var returnFundSlices = new List<MutualFundSlice>();
            foreach (var fundSlice in VFIAX_list)
                returnFundSlices.Add(CopyFund(fundSlice));
            return await Task.FromResult(returnFundSlices);
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

        public async Task<bool> UpdateMutualFundSlicesAsync(MutualFundSlice fundSlice)
        {
            var fundIndex = VFIAX_list.FindIndex((MutualFundSlice arg) => arg.Id == fundSlice.Id);
            var fundFound = fundIndex != -1;
            if (fundFound)
            {
                VFIAX_list[fundIndex].name = fundSlice.name;
                VFIAX_list[fundIndex].symbol = fundSlice.symbol;
                VFIAX_list[fundIndex].url = fundSlice.url;
                VFIAX_list[fundIndex].Assets = fundSlice.Assets;
            }
            return await Task.FromResult(fundFound);
        }

        public async Task<IList<string>> GetMutualFundSliceNamesAsync()
        {
            return await Task.FromResult(mockMutualFundNames);
        }

       
    }
}


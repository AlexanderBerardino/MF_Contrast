using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models;
using Xamarin.Forms;

namespace MFContrast.Services
{
    public class CalculatePostCompare : ICalculatePostCompare
    {


        // This should be a service that creates and sets properties for a PostCompare data model 
        static CalculatePostCompare()
        {

        }

        private async Task<IList<string>> GetHoldingTicker(MutualFund fund1, MutualFund fund2, int switchCase)
        {

            switch (switchCase) {

                case 1:
                    var Holdings1 = fund1.AssetList;
                    var symbols = new List<string>();
                    foreach (var Holding in Holdings1)
                    {
                        symbols.Add(string.Copy(Holding.Symbol));
                    }
                    return await Task.FromResult(symbols);
                case 2:
                    var Holdings2 = fund2.AssetList;
                    var names2 = new List<string>();
                    foreach (var Holding in Holdings2)
                    {
                        names2.Add(string.Copy(Holding.Symbol));
                    }
                    return await Task.FromResult(names2);
                default:
                    Console.Write("Default Reached");
                    return await Task.FromResult(new List<string>());


            }
        }

        public async Task<IList<string>> CalculateOverlap(MutualFund fund1, MutualFund fund2)
        {
            IList<string> a1 = await GetHoldingTicker(fund1, fund2, 1);
            IList<string> a2 = await GetHoldingTicker(fund1, fund2, 2);
            // Command aa = new Command(async () => await GetHoldingTicker(fund1, fund2, 1));
            

            List<string> returnHolding = new List<string>();

            
            foreach(var name in a1)
            {
                if (a2.Contains(name))
                {
                    returnHolding.Add(string.Copy(name));
                }
            }
            return await Task.FromResult(returnHolding);
        }


        public async Task<IList<string>> CalculateUniqueHoldings1(MutualFund fund1, MutualFund fund2)
        {
            var returnHolding = new List<string>();

            IList<string> Holding1Tickers = await GetHoldingTicker(fund1, fund2, 1);
            IList<string> Holding2Tickers = await GetHoldingTicker(fund1, fund2, 2);

            foreach (var name in Holding1Tickers)
            {
                if (!Holding2Tickers.Contains(name))
                {
                    returnHolding.Add(string.Copy(name));
                }
            }
            return await Task.FromResult(returnHolding);
        }


        public async Task<IList<string>> CalculateUniqueHoldings2(MutualFund fund1, MutualFund fund2)
        {
            var returnHolding = new List<string>();


            var Holding1Tickers = await GetHoldingTicker(fund1, fund2, 1);
            var Holding2Tickers = await GetHoldingTicker(fund1, fund2, 2);

            foreach (var name in Holding2Tickers)
            {
                if (!Holding1Tickers.Contains(name))
                {
                    returnHolding.Add(string.Copy(name));
                }
            }
            return await Task.FromResult(returnHolding);
        }

        public float Get1In2()
        {
            throw new NotImplementedException();
        }

        public float Get2In1()
        {
            throw new NotImplementedException();
        }

        public float GetOverlapByWeight()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetOverlapHoldingsNumber(MutualFund fund1, MutualFund fund2)
        {
            IList<string> Overlap = await CalculateOverlap(fund1, fund2);
            int OverlapNumber = Overlap.Count;
            return await Task.FromResult(OverlapNumber);
        }


    }
}

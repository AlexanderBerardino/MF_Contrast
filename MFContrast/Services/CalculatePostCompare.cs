using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models;

namespace MFContrast.Services
{
    public class CalculatePostCompare : ICalculatePostCompare
    {


        public IList<Holding> Holdings2;
        public IList<Holding> Holdings1;
        
        public IList<string> Holding1Names;
        public IList<string> Holding2Names;
       

        public calculatePostCompare PostCompareModel;


        // This should be a service that creates and sets properties for a PostCompare data model 
        public CalculatePostCompare(MutualFund fund1, MutualFund fund2)
        {

            PostCompareModel = new calculatePostCompare(fund1, fund2);
            Holdings1 = fund1.AssetList;
            Holdings2 = fund2.AssetList;

        }

        public async Task<IList<string>> GetHoldingNames(int switchCase)
        {
            switch (switchCase) {

                case 1:
                    var names = new List<string>();
                    foreach (var Holding in Holdings1)
                    {
                        names.Add(string.Copy(Holding.Name));
                    }
                    return await Task.FromResult(names);
                case 2:
                    var names2 = new List<string>();
                    foreach (var Holding in Holdings2)
                    {
                        names2.Add(string.Copy(Holding.Name));
                    }
                    return await Task.FromResult(names2);
                default:
                    Console.Write("Default Reached");
                    return await Task.FromResult(new List<string>());


            }
        }

        public async Task<IList<string>> CalculateOverlap()
        {
            IList<string> a1 = await GetHoldingNames(1);
            IList<string> a2 = await GetHoldingNames(2);

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


        public async Task<IList<string>> CalculateUniqueHoldings1()
        {
            var returnHolding = new List<string>();

            foreach (var name in Holding1Names)
            {
                if (!Holding2Names.Contains(name))
                {
                    returnHolding.Add(string.Copy(name));
                }
            }
            return await Task.FromResult(returnHolding);
        }


        public async Task<IList<string>> CalculateUniqueHoldings2()
        {
            var returnHolding = new List<string>();

            foreach (var name in Holding2Names)
            {
                if (!Holding1Names.Contains(name))
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

        public async Task<int> GetOverlapHoldingsNumber()
        {
            IList<string> Overlap = await CalculateOverlap();
            int OverlapNumber = Overlap.Count;
            return await Task.FromResult(OverlapNumber);
        }


    }
}

using System;
using MFContrast.Services;
using MFContrast.Models;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace MFUnitTests
{
    public class QueryUnitTest
    {
        public IFundQuery<IList<Holding>, IEnumerable<Holding>> Query { get; set; }
        public DictionaryBasedCompare DictionaryBasedCompare { get; set; }

        public MutualFund MockFundOne { get; set; }
        public MutualFund MockFundTwo { get; set; }

        public List<Holding> Holdings1 => MockFundOne.AssetList;
        public List<Holding> Holdings2 => MockFundTwo.AssetList;

        public List<Holding> CleanedHoldings1 { get; set; }
        public List<Holding> CleanedHoldings2 { get; set; }

        public QueryUnitTest()
        {
            Query = new ListFundQuery<IList<Holding>, IEnumerable<Holding>>();
           

            MockFundOne = new MutualFund("vfiax")
            {
                Id = "0",
                FundName = "Vanguard",
            };

            MockFundTwo = new MutualFund("fcntx")
            {
                Id = "1",
                FundName = "Fidelity",
            };

            CleanedHoldings1 = Query.RemoveNullHoldings(Holdings1).ToList();
            CleanedHoldings2 = Query.RemoveNullHoldings(Holdings2).ToList();

            DictionaryBasedCompare = new DictionaryBasedCompare(MockFundOne.AssetList, MockFundTwo.AssetList);
        }

        [Fact]
        public void TestRemoveNullHoldings()
        {
            List<Holding> DBC = DictionaryBasedCompare.S1;
            IEnumerable<Holding> queryEnumberable = Query.RemoveNullHoldings(Holdings1);
            List<Holding> queryList = queryEnumberable.ToList();
            Assert.Equal(DBC, queryList);
        }

        [Fact]
        public void TestTopTen()
        {
            double DBC_Answer = DictionaryBasedCompare.F1TopTen;
            double queryAnswer = Query.TopTen(Holdings1);
            Assert.Equal(DBC_Answer, queryAnswer, 3);           
        }

        [Fact]
        public void TestDistillUnion()
        {
            List<string> DBC = DictionaryBasedCompare.S1UnionS2;

            IEnumerable<string> queryEnumberable = Query.DistillUnion(CleanedHoldings1, CleanedHoldings2);
            List<string> queryToList = queryEnumberable.ToList();

            Assert.Equal(DBC, queryToList);
        }

        [Fact]
        public void TestDistillDifference()
        {
            List<Holding> DBC = DictionaryBasedCompare.S1Complement;
            List<Holding> q = Query.DistillDifference(CleanedHoldings2, CleanedHoldings1).ToList();
            Assert.Equal(DBC, q);
        }

        [Fact]
        public void TestWeightedAverage()
        {
            List<string> queryUnion = Query.DistillUnion(CleanedHoldings1, CleanedHoldings2);
            double q = Query.WeightedAverage(Holdings1, queryUnion);
            double DBC = DictionaryBasedCompare.F2InF1;
            Assert.Equal(DBC, q);
        }
    }
}

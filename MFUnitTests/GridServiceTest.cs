using System;
using Xamarin.Forms;
using MFContrast.Services;
using Xunit;

namespace MFUnitTests
{
    public class GridServiceTest
    {
        public MockFunds MockFunds { get; set; }
        public string[] HeaderText { get; set; }
        public GridServiceClient GridServiceClient { get; set; }
        public int MainGridRowNumber { get; set; }
        public string TestCell1 { get; set; }
        

        public GridServiceTest()
        {
            MockFunds = new MockFunds();
            MainGridRowNumber = MockFunds.MockFund1.AssetList.Count;
            HeaderText = new string[]{ "sample1", "sample2", "sample3"};
            GridServiceClient = new GridServiceClient(HeaderText, MockFunds.MockFund1.AssetList);
        }

        [Fact]
        public void HeaderGridValid()
        {
            Assert.NotNull(GridServiceClient.HeaderGrid);
        }

        [Fact]
        public void MainGridValid()
        {
            Assert.NotNull(GridServiceClient.MainGrid);
        }

        [Fact]
        public void MainGridRowNumberTest()
        {
            Assert.Equal(MainGridRowNumber, GridServiceClient.MainGrid.RowDefinitions.Count);
        }
    }
}

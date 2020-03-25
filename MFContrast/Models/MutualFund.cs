using System;
using System.Collections.Generic;
using MFContrast.Services;

namespace MFContrast.Models
{
    public class MutualFund
    {
        public string FundName { get; set; }
        public List<Holding> AssetList { get; set; }
        public string Ticker { get; set; }
        public string Id { get; set; }
        // Expense ratio
        // Number of holdings
        // Type of holdings
        // Type of fund 


        public MutualFund(string Ticker)
        {

            this.Ticker = Ticker;
            AssetList = GenerateHoldingsList.Create(Ticker);
            
        }


    }
}

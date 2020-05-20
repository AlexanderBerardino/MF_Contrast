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
        public string KeyName { get; set; }
        // POSSIBLE FUTURE PROPERTIES

        // Expense ratio
        // Number of holdings
        // Type of holdings
        // Type of fund 

        public MutualFund(string Ticker)
        {
            this.Ticker = Ticker;
            KeyName = KeyNameSuffix(Ticker);

            // Binds to Asset List
            GenerateHoldingsList lister = new GenerateHoldingsList();
            AssetList = lister.Create(Ticker);
        }

        private static string KeyNameSuffix(string Ticker)
        {
            return string.Join("", "CsvDataTables/", Ticker.ToLower(), "_holdings.csv");
        }
    }
}

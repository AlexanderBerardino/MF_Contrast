using System.Collections.Generic;
using MFContrast.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace MFContrast.Models
{
    public class MutualFund
    {
        // GetHoldingsList GetHoldingsList => DependencyService.Get<GetHoldingsList>();
        //public IAWSGenerateHoldingsList AWSGenerate =>
        //    DependencyService.Get<IAWSGenerateHoldingsList>() ?? new AWSGenerateHoldingsList();

        public string FundName { get; set; }
        public List<Holding> AssetList { get; set; }
        public Command LoadAssetListCommand { get; set; }
        public bool CanEx { get; set; }
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
            // CanEx = LoadAssetListCommand.CanExecute(ExecuteLoadAssetListCommand(KeyName));
            // LoadAssetListCommand = new Command(async () => await ExecuteLoadAssetListCommand(KeyName));
            // OLD WAY 
            var lister = new GenerateHoldingsList();
            AssetList = lister.Create(Ticker);
        }

        private static string KeyNameSuffix(string Ticker)
        {
            return string.Join("", "CsvDataTables/", Ticker.ToLower(), "_holdings.csv");
        }

        //private async Task ExecuteLoadAssetListCommand(string keyName)
        //{
        //    try
        //    {
        //        AssetList = new List<Holding>();
        //        var holdings = await AWSGenerate.CreateAsync(keyName);
        //        foreach (var holding in holdings)
        //        {
        //            AssetList.Add(holding);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //}
    }
}

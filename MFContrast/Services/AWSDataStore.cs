using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFContrast.Models;

namespace MFContrast.Services
{
    public class AWSDataStore : IMutualFundDataStore
    {
        // private static readonly List<MutualFund> FundList;
        public AWSDataStore()
        {
        }

        public Task<string> AddItemAsync(MutualFund fund)
        {
            throw new NotImplementedException();
        }

        public Task<MutualFund> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<MutualFund>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }
    }


    public class MFUrlDictionary
    {
        public Dictionary<string, string> UrlDict { get; set; }

        public MFUrlDictionary()
        {
            UrlDict = new Dictionary<string, string>
            {
                {"vfiax", "https://mfcontrast.s3.us-east-2.amazonaws.com/CsvDataTables/vfiax_holdings.csv" },
                {"fcntx", "https://mfcontrast.s3.us-east-2.amazonaws.com/CsvDataTables/fcntx_holdings.csv" },
                {"vsmax","https://mfcontrast.s3.us-east-2.amazonaws.com/CsvDataTables/vsmax_holdings.csv" },
            };
        }
    }
}

using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
namespace MFContrast.Services
{
    public class ConvertCsvTable 
    {
        // DataTable to hold MF csv data
        public readonly DataTable csvTable;
        // Reader for parsing csv DataTable
        private readonly CsvReader csvReader;


        // Default constructor, using vfiax_holdings.csv in WRDS directory
        public ConvertCsvTable()
        {
            csvTable = new DataTable();

            // Declaration will need to be abstracted for different funds
            // Must add argument 'fileName' of type string to alter path for specific fund 
            csvReader = new CsvReader(new StreamReader(File.OpenRead(@"D:../WRDS/vfiax_holdings.csv")), true);
            LoadReader();
        }

        // Path name chosen in constructor
        public ConvertCsvTable(string csvPath)
        {
            csvTable = new DataTable();

            // Declaration will need to be abstracted for different funds
            // Must add argument 'fileName' of type string to alter path for specific fund 
            csvReader = new CsvReader(new StreamReader(File.OpenRead(@csvPath)), true);
            LoadReader();
        }

        // Adds CsvReader object to DataTable object
        private void LoadReader()
        {
            using (csvReader)
            {
                csvTable.Load(csvReader);
            }
            
        }

        

        // Args :: Name of Column you want to get values of
        // Example arg: "Name" for mutual fund names
        public Task<string> GetColumn(string columnType)
        {
            switch (columnType)
            {
                case "Name":
                    string NameColumn = csvTable.Columns[4].ToString();
                    return Task.FromResult(NameColumn);
                case "Percentage":
                    string PercentageColumn = csvTable.Columns[3].ToString();
                    return Task.FromResult(PercentageColumn);
                case "Rank":
                    string RankColumn = csvTable.Columns[1].ToString();
                    return Task.FromResult(RankColumn);
                default:
                    Console.WriteLine("Default Case Reached");
                    return null;

            }
        }

        // Iterates through Rows searching for matching asset name input
        // Input must be uppercase and match name exactly
        // Example arg: "MICROSOFT CORP"
        public Task<string> GetAssetInfoByName(string assetName)
        {
            int i = 0;
            while (i < csvTable.Rows.Count)
            {
                if (csvTable.Rows[i][3].ToString() == assetName)
                {
                    string assetInfo = csvTable.Rows[i].ToString();
                    return Task.FromResult(assetInfo);
                   
                }
                i++;
            }

            Console.WriteLine("Search Ended on line " + i);
            Console.WriteLine("Asset Not Found");
            return null;
        }

        // Get specific value from a single cell
        // y: row number
        // x: cell in row number
        // Example arg: 4th cell in row 10 => (9, 3)
        // Need to test to see if index begins at 0 or 1

        public Task<string> GetSpecificCellValue(int y, int x)
        {
            string specificValue = csvTable.Rows[y][x].ToString();
            return Task.FromResult(specificValue);
        }

    }
}

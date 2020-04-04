using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using MFContrast.Models;

namespace MFContrast.Services
{
    interface IGetHoldingsList
    {
        List<Holding> Create(string Ticker);
    }

    public class GenerateHoldingsList : IGetHoldingsList
    {
        public GenerateHoldingsList()
        {
        }

        static string CreateCsvPath(string urlPrefix)
        {
            return string.Join("", urlPrefix, "_holdings.csv");
        }

        static DataTable CreateDataTable(string tickerSymbol)
        {
            DataTable CsvTable = new DataTable();

            string csvPath = CreateCsvPath(tickerSymbol);

            // Declaration will need to be abstracted for different funds
            // Must add argument 'fileName' of type string to alter path for specific fund 
            bool doesExist = File.Exists(csvPath);
            if (doesExist)
            {
                CsvReader reader = new CsvReader(new StreamReader(File.OpenRead(@csvPath)), true);
                using (reader)
                {
                    CsvTable.Load(reader);
                }

                return CsvTable;
            }
            else
            {
                throw new Exception("csvPath Constructor");
            }          
        }

        public List<Holding> Create(string Ticker)
        {
            DataTable data = CreateDataTable(Ticker);

            List<Holding>HoldingsList = new List<Holding>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                HoldingsList.Add(new Holding
                {
                    Name = data.Rows[i][4].ToString(),
                    Rank = data.Rows[i][1].ToString(),
                    Percentage = data.Rows[i][3].ToString(),
                    Symbol = data.Rows[i][5].ToString()
                });
            }
            return HoldingsList;
        }
    }
}

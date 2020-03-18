using System;
using System.Threading.Tasks;

namespace MFContrast.Services
{
    public interface IConvertCsvTable
    {
        Task<string> GetColumn(string columnType);
        Task<string> GetAssetInfoByName(string assetName);
        Task<string> GetSpecificCellValue(int y, int x);
       

        // Will be implemented by ConvertTest.cs
    }
}

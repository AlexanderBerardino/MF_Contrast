using System.Collections.Generic;
namespace MFContrast.Services
{
    public interface IConvertHtmTable
    {
        List<List<string>> GetTable();
        void SetTable();
        
    }
}

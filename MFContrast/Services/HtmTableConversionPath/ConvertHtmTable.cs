using System.Collections.Generic;
using System.Linq;

namespace MFContrast.Services
{
    public class ConvertHtmTable : IConvertHtmTable
    {
        private HtmlAgilityPack.HtmlDocument mf_doc;
        private List<List<string>> mf_table;

        public ConvertHtmTable()
        {
            mf_doc = new HtmlAgilityPack.HtmlDocument();
            mf_doc.Load("./WRDS/CRISP_MF_1022248.htm");
            SetTable();
        }

        public void SetTable()
        {
            mf_table = mf_doc.DocumentNode.SelectSingleNode("//table[@class='table']").Descendants("tr").Skip(1).Where(tr => tr.Elements("td").Count() > 1)
            .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
            .ToList();
        }
        public List<List<string>> GetTable()
        {
            return mf_table;
        }
    }
}

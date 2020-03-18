using System.Collections.Generic;
namespace MFContrast.Models
{
    public class MutualFundWhole
    {
        public string fund_name { get; set; }
        public List<MutualFundSlice> fund_list { get; set; }
        // public int fund_size { get; set; }
        public MutualFundWhole(string fund_name)
        {
            this.fund_name = fund_name;
        }
        public MutualFundWhole()
        {

        }
    }
}

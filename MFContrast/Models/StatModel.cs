using System;
using System.Collections.ObjectModel;

namespace MFContrast.Models
{
    public class StatModel
    {
        public string StatTitle { get; set; }
        public string StatValue { get; set; }

        public StatModel()
        {
        }
    }

    public class GroupedStatModel : ObservableCollection<StatModel>
    {
        public string GroupStatTitle { get; set; }
    }
}

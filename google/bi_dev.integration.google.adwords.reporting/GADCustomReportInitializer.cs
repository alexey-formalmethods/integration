using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public class GADCustomReportInitializer
    {
        public GADConfig Config { get; set; }

        public GADAccount Account { get; set; }
        public ICollection<GADCustomColumn> Columns { get; set; }
        public GADCustomReportType Type { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }


    }
}

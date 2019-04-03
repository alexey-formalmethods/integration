using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public class GADCustomReportInitializer: ICustomReportInitializer
    {
        public GADConfig Config { get; set; }

        public GADAccount Account { get; set; }
        public IDictionary<string, CustomReportColumn> Columns { get; set; }
        public GADCustomReportType Type { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}

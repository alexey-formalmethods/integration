using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public class GADCustomReportInitializer: ICustomReportInitializer
    {
        public GADConfig Config { get; set; }

        public GADAccount Account { get; set; }
        public IDictionary<string, CustomReportColumn> Columns { get; }
        public GADCustomReportType Type { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public GADCustomReportInitializer(GADConfig config, string accountId, string[] columns, string reportType, DateTime dateFrom, DateTime dateTo)
        {
            this.Config = config;
            this.Account = new GADAccount(accountId);
            if (columns == null || columns.Length == 0) throw new ArgumentException("no columns passed");
            this.Columns = columns.Select(x => (CustomReportColumn)new CustomReportColumn<string>(x)).ToDictionary(x => x.Name.ToLower(), x => x);
            this.Type = new GADCustomReportType(reportType);
            this.DateStart = dateFrom;
            this.DateEnd = dateTo;
        }
    }
}

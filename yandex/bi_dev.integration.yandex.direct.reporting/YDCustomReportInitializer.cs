using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bi_dev.integration.yandex.direct.reporting
{
    public class YDCustomReportInitializer : ICustomReportInitializer
    {
        public YDConfig Config { get; }
        public DateTime DateFrom { get; }
        public DateTime DateTo { get; }
        public string ReportType { get; }
        public IDictionary<string, CustomReportColumn> Columns { get; }
        public bool IncludeVAT { get; }
        public YDCustomReportInitializer(YDConfig config, string reportType, DateTime dateFrom, DateTime dateTo, ICollection<string> columns, bool includeVAT)
        {
            this.Config = config;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
            this.ReportType = reportType;
            this.Columns = columns.ToDictionary(x => x, x => (CustomReportColumn)new CustomReportColumn<string>(x));
        }
    }
}

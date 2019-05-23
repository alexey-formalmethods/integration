using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.direct.reporting
{
    public class YDCustomReport : CustomReport<YDCustomReportInitializer>
    {
        public YDCustomReport(YDCustomReportInitializer initializer) : base(initializer)
        {
            this.Rows = new List<CustomReportRow>();
        }
    }
}

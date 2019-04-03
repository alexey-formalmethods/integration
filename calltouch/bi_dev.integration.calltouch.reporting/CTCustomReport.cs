using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Data;

namespace bi_dev.integration.calltouch.reporting
{
    public class CTCustomReport : CustomReport<CTCustomReportInitializer>
    {
        public CTCustomReport(CTCustomReportInitializer initializer): base (initializer)
        {
        }
    }
}

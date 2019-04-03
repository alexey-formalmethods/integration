using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.calltouch.reporting
{
    public class CTCustomReportManager : CustomReportManager<CTCustomReport, CTCustomReportInitializer, ICTCustomReportReceiver>
    {
        public CTCustomReportManager(ICTCustomReportReceiver receiver) : base(receiver)
        {
        }
    }
}

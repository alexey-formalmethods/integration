using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.sheets.reporting
{
    public class GSReportManager : CustomReportManager<GSReport, GSReportInitializer, IGSReportReceiver>
    {
        public GSReportManager(IGSReportReceiver receiver) : base(receiver)
        {
        }
    }
}

using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.sheets.reporting
{
    public interface IGSReportReceiver : ICustomReportReceiver<GSReport, GSReportInitializer>
    {
    }
}

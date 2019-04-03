using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public interface IGCustomReportReceiver: ICustomReportReceiver<GCustomReport, GCustomReportInitializer>
    {
    }
}

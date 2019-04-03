using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.calltouch.reporting
{
    public interface ICTCustomReportReceiver: ICustomReportReceiver<CTCustomReport, CTCustomReportInitializer>
    {
    }
}

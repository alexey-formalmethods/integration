using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public interface IGCustomReportReceiver
    {
        GCustomReport Get(GCustomReportInitializer initializer);
    }
}

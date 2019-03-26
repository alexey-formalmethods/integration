using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public interface IGADCustomReportReceiver
    {
        GADCustomReport Get(GADCustomReportInitializer initializer);
    }
}

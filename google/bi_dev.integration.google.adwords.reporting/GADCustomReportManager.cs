using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public class GADCustomReportManager: CustomReportManager<GADCustomReport, GADCustomReportInitializer, IGADCustomReportReceiver>
    {
        public GADCustomReportManager(IGADCustomReportReceiver receiver) : base(receiver)
        {
        }
    }
}

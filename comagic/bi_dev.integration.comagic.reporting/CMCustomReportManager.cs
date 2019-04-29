using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.comagic.reporting
{
    public class CMCustomReportManager : CustomReportManager<CMCustomReport, CMCustomReportInitializer, CMCustomReportReceiver>
    {
        public CMCustomReportManager(CMCustomReportReceiver receiver) : base(receiver)
        {
        }
    }
}

using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.comagic.reporting
{
    public class CMCustomReport : CustomReport<CMCustomReportInitializer>
    {
        public CMCustomReport(CMCustomReportInitializer initializer) : base(initializer)
        {
        }
    }
}

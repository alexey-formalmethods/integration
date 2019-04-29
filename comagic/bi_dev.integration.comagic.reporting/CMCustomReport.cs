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
    public class CMCustomReportRow: CustomReportRow
    {

    }
    public class CMCustomReportColumn : CustomReportColumn<string>
    {
        public CMCustomReportColumn(string name) : base(name)
        {
        }
    }
}

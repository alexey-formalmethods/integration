using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.gitlab.reporting
{
    public class GLCustomReport : CustomReport<GLCustomReportInitializer>
    {
        public GLCustomReport(GLCustomReportInitializer initializer) : base(initializer)
        {
        }
    }
}

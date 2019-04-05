using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.gitlab.reporting
{
    public class GLRestIssuesReportReceiver : ICustomReportReceiver<GLCustomReport, GLCustomReportInitializer>
    {
        public GLCustomReport Get(GLCustomReportInitializer initializer)
        {
            throw new NotImplementedException();
        }
    }
}

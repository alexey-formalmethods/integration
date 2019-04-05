using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.gitlab.reporting
{
    public class GLCustomReportInitializer : ICustomReportInitializer
    {
        public IDictionary<string, CustomReportColumn> Columns => throw new NotImplementedException();
    }
}

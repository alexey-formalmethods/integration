using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.reporting
{
    public interface ICustomReportInitializer
    {
        IDictionary<string, CustomReportColumn> Columns { get; }
    }
}

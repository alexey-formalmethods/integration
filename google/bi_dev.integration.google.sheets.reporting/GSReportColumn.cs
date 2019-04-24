using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.sheets.reporting
{
    public class GSReportColumn : CustomReportColumn
    {
        public GSReportColumn(Type valueType, string name, string alterName) : base(valueType, name, alterName)
        {
        }
    }
}

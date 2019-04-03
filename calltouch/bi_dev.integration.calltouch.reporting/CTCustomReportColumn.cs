using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.calltouch.reporting
{
    public class CTCustomReportColumn: CustomReportColumn
    {
        public CTCustomReportColumn(string name) : base(typeof(string), name) { }
    }
    public class CTCustomReportCell: CustomReportCell
    {
        public CTCustomReportCell(string name, string value) : base(new CTCustomReportColumn(name), value) { }
    }
}

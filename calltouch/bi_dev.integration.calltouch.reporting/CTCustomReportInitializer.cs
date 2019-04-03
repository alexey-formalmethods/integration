using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.calltouch.reporting
{
    public class CTCustomReportInitializer : ICustomReportInitializer
    {
        private DateTime dateFrom;
        private DateTime dateTo;
        private ICollection<CTCustomReportColumn> columns;
        public CTCustomReportInitializer(DateTime dateFrom, DateTime dateTo, ICollection<CTCustomReportColumn> columns)
        {
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
            this.columns = columns;
        }
        public IDictionary<string, CustomReportColumn> Columns
        {
            get
            {
                Dictionary<string, CustomReportColumn> cols = new Dictionary<string, CustomReportColumn>();
                foreach (var col in this.columns)
                {
                    if (!cols.ContainsKey(col.AlterName))
                    {
                        cols.Add(col.AlterName, col);
                    }
                }
                return cols;
            }
        }
                
            

    }
}

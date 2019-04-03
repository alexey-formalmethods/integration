using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bi_dev.integration.calltouch.reporting
{
    public class CTCustomReportInitializer : ICustomReportInitializer
    {
        private DateTime dateFrom;
        public DateTime DateFrom { get { return this.dateFrom; } }
        private DateTime dateTo;
        public DateTime DateTo { get { return this.dateTo; } }
        private ICollection<CTCustomReportColumn> columns;
        public CTCustomReportInitializer(DateTime dateFrom, DateTime dateTo, ICollection<CTCustomReportColumn> columns)
        {
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
            this.columns = columns;
        }
        public CTCustomReportInitializer(DateTime dateFrom, DateTime dateTo, ICollection<string> columns)
        {
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
            this.columns = columns.Select(x=>new CTCustomReportColumn(x)).ToArray();
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

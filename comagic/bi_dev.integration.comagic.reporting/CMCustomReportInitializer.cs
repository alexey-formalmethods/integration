using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bi_dev.integration.comagic.reporting
{
    public class CMCustomReportInitializer : ICustomReportInitializer
    {
        public string ReportType { get; }
        public DateTime DateFrom { get; }
        public DateTime DateTo { get;}
        public ICollection<string> ColumnNames { get; }
        public bool NoColumnsPassed { get; }
        private IDictionary<string, CustomReportColumn> columns;
        public CMCustomReportInitializer(string reportType, DateTime dateFrom, DateTime dateTo, ICollection<string> columnNames)
        {
            this.ReportType = reportType;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
            this.ColumnNames = (columnNames == null)?new string [0] : columnNames;
            this.NoColumnsPassed = (this.ColumnNames == null || this.ColumnNames.Count == 0) ? true : false;
            this.columns = this.ColumnNames.ToDictionary(x => x, y => (CustomReportColumn)new CMCustomReportColumn(y));

        }
        public IDictionary<string, CustomReportColumn> Columns
        {
            get { return this.columns; }
            set { this.columns = value; }
        }
    }
}

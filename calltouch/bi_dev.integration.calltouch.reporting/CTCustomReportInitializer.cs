using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace bi_dev.integration.calltouch.reporting
{
    public class CTCustomReportInitializer : ICustomReportInitializer
    {
        public string SiteId { get; }
        public DateTime DateFrom { get; }
        public DateTime DateTo { get; }
        public ICollection<string> ColumnNames { get; }
        public bool NoColumnsPassed { get; }
        private IDictionary<string, CustomReportColumn> columns;
        public CTCustomReportInitializer(string siteId, DateTime dateFrom, DateTime dateTo, ICollection<string> columnNames)
        {
            this.SiteId = siteId;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
            this.ColumnNames = (columnNames == null) ? new string[0] : columnNames;
            this.NoColumnsPassed = (this.ColumnNames == null || this.ColumnNames.Count == 0) ? true : false;
            this.columns = this.ColumnNames.ToDictionary(x => x, y => (CustomReportColumn)new CTCustomReportColumn(y));
        }
        public CTCustomReportInitializer(string siteId, string dateFrom, string dateTo, ICollection<string> columnNames)
        {
            this.SiteId = siteId;
            CultureInfo provider = CultureInfo.InvariantCulture;
            this.DateFrom = DateTime.ParseExact(dateFrom, CTConstants.InputDateFormat, provider);
            this.DateTo = DateTime.ParseExact(dateTo, CTConstants.InputDateFormat, provider);
            this.ColumnNames = (columnNames == null) ? new string[0] : columnNames;
            this.NoColumnsPassed = (this.ColumnNames == null || this.ColumnNames.Count == 0) ? true : false;
            this.columns = this.ColumnNames.ToDictionary(x => x, y => (CustomReportColumn)new CTCustomReportColumn(y));
        }
        public IDictionary<string, CustomReportColumn> Columns
        {
            get { return this.columns; }
            set { this.columns = value; }
        }
                
            

    }
}

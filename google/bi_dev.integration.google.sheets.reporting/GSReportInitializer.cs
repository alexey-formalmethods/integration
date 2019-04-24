using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bi_dev.integration.google.sheets.reporting
{
    public class GSReportInitializer : ICustomReportInitializer
    {
        private IDictionary<string, CustomReportColumn> columns;
        public IDictionary<string, CustomReportColumn> Columns
        {
            get
            {
                return this.columns;
            }
            set
            {
                this.columns = value;
            }
        }
        public string SheetId { get; }
        public string TabName { get; }
        public string Diapasone { get; }
        private KeyValuePair<string, string> [] columnNames { get; }
        public GSReportInitializer(string sheetId, string tabName, string diapasone, KeyValuePair<string, string> [] columnNames)
        {
            this.SheetId = sheetId;
            this.TabName = tabName;
            this.Diapasone = diapasone;
            this.columnNames = columnNames;
            this.columns = columnNames.ToDictionary(x => x.Key, x => (CustomReportColumn)new GSReportColumn(typeof(string), x.Key, x.Value));
        }

    }
}

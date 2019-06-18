using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace bi_dev.integration.yandex.direct.reporting
{
    public class YDCustomReport : CustomReport<YDCustomReportInitializer>
    {
        public bool IsReady { get; set; }
        public YDCustomReport(YDCustomReportInitializer initializer) : base(initializer)
        {
            this.Rows = new List<CustomReportRow>();
            this.IsReady = true;
        }
        public YDCustomReport(YDCustomReportInitializer initializer, bool isReady) : base(initializer)
        {
            this.Rows = new List<CustomReportRow>();
            this.IsReady = isReady;
        }
        public override DataTable ToDataTable()
        {
            var dt = base.ToDataTable();
            dt.Columns.Add("prm_date_from", typeof(DateTime));
            dt.Columns.Add("prm_date_to", typeof(DateTime));
            foreach(DataRow row in dt.Rows)
            {
                row["prm_date_from"] = initializer.DateFrom;
                row["prm_date_to"] = initializer.DateTo;
            }
            return dt;

        }
    }
}

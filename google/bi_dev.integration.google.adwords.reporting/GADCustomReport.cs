using bi_dev.integration.reporting;
using bi_dev.integration.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public class GADCustomReport: CustomReport<GADCustomReportInitializer>
    {

        public GADCustomReport(GADCustomReportInitializer initializer) : base(initializer) { }

        public override DataTable ToDataTable()
        {
            DataTable dt = base.ToDataTable();
            dt.Columns.Add(new DataColumn("account_id", typeof(string)));
            dt.Columns.Add(new DataColumn("date_from", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("date_to", typeof(DateTime)));
            foreach (DataRow row in dt.Rows)
            {
                row["account_id"] = Initializer.Account.Id;
                row["date_from"] = Initializer.DateStart;
                row["date_to"] = Initializer.DateEnd;
            }
            return dt;
        }
    }
    
}

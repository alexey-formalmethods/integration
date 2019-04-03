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
            foreach (var row in dt.Rows)
            {
                var dtRow = dt.NewRow();
                dtRow["account_id"] = Initializer.Account.Id;
                dtRow["date_from"] = Initializer.DateStart;
                dtRow["date_to"] = Initializer.DateEnd;
            }
            return dt;
        }
    }
    
}

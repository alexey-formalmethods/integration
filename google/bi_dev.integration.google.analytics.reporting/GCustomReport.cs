using bi_dev.integration.reporting;
using bi_dev.integration.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GCustomReport: CustomReport<GCustomReportInitializer>
    {
		public GCustomReport (GCustomReportInitializer initializer): base (initializer)
		{
		}
		public override DataTable ToDataTable()
		{

            DataTable dt = base.ToDataTable();
			dt.Columns.Add("view_id", typeof(string));
			dt.Columns.Add("date_from", typeof(DateTime));
			dt.Columns.Add("date_to", typeof(DateTime));
			
			foreach (DataRow row in dt.Rows)
			{
                row["view_id"] = initializer.View.Id;
                row["date_from"] = initializer.DateStart;
                row["date_to"] = initializer.DateEnd;
			}
			return dt;
		}
	}
	
}

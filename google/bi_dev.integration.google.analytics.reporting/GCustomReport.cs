using bi_dev.integration.reporting;
using bi_dev.integration.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GCustomReport: CustomReport<GCustomReportInitializer>, IDataTableTransformable
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
			
			foreach (var row in this.Rows)
			{
				var dtRow = dt.NewRow();
				dtRow["view_id"] = initializer.View.Id;
				dtRow["date_from"] = initializer.DateStart;
				dtRow["date_to"] = initializer.DateEnd;
			}
			return dt;
		}
	}
	
}

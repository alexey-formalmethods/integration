using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
	public class YCustomReport: CustomReport<YReportInitializer>
	{
		public YCustomReport(YReportInitializer initializer): base (initializer) { }
		public override DataTable ToDataTable()
		{
            DataTable dt = base.ToDataTable();
			dt.Columns.Add("counter_id", typeof(int));
			dt.Columns.Add("date_from", typeof(DateTime));
			dt.Columns.Add("date_to", typeof(DateTime));
			foreach (DataRow row in dt.Rows)
			{
				row["counter_id"] = initializer.Counter.Id;
                row["date_from"] = initializer.DateStart;
                row["date_to"] = initializer.DateEnd;
			}
			return dt;
		}
	}
	
}

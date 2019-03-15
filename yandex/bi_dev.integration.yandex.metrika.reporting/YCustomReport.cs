using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
	public class YCustomReport
	{
		protected YBaseReportInitializer initializer;
		public YCustomReport(YBaseReportInitializer initializer)
		{
			this.initializer = initializer;
		}
		public ICollection<CustomReportRow> Rows { get; set; }
		public DataTable ToDataTable()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("counter_id", typeof(int));
			dt.Columns.Add("date_from", typeof(DateTime));
			dt.Columns.Add("date_to", typeof(DateTime));
			dt.Columns.AddRange(initializer.DimensionMetricsParams.Select(x => new DataColumn(x.Name, typeof(string))).ToArray());
			foreach (var row in this.Rows)
			{
				var dtRow = dt.NewRow();
				dtRow["counter_id"] = initializer.Counter.Id;
				dtRow["date_from"] = initializer.DateStart;
				dtRow["date_to"] = initializer.DateEnd;
				foreach (var cell in row.Cells)
				{
					dtRow[cell.Name] = cell.Value;
				}
				dt.Rows.Add(dtRow);
			}
			return dt;
		}
	}
	public class CustomReportRow
	{
		public ICollection<IYCustomParameterValued> Cells { get; set; }
		public CustomReportRow(ICollection<IYCustomParameterValued> cells)
		{
			this.Cells = cells;
		}
	}
}

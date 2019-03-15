using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GCustomReport
    {
		protected GBaseReportInitializer initializer;
		public GCustomReport (GBaseReportInitializer initializer)
		{
			this.initializer = initializer;
		}
		public ICollection<CustomReportRow> Rows { get; set; }
		public DataTable ToDataTable()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("view_id", typeof(string));
			dt.Columns.Add("date_from", typeof(DateTime));
			dt.Columns.Add("date_to", typeof(DateTime));
			dt.Columns.AddRange(initializer.DimensionMetricsParams.Select(x => new DataColumn(x.Name, typeof(string))).ToArray());
			foreach (var row in this.Rows)
			{
				var dtRow = dt.NewRow();
				dtRow["view_id"] = initializer.View.Id;
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
		public ICollection<IGCustomParameterValued> Cells { get; set; }
		public CustomReportRow(ICollection<IGCustomParameterValued> cells)
		{
			this.Cells = cells;
		}
	}
}

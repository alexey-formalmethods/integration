using bi_dev.integration.utils.mssql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace bi_dev.integration.google.analytics.reporting.storage
{
	public class MsSqlReportSaver : IReportSaver
	{
		private string connectionString;
		private string tableName;
		private string schemaName;
		private string dbName;
		public MsSqlReportSaver(string connectionString, string tableName, string schemaName = null, string dbName = null)
		{
			this.connectionString = connectionString;
			this.tableName = tableName;
			this.schemaName = string.IsNullOrWhiteSpace(schemaName)? "dbo": schemaName;
			var builder = new SqlConnectionStringBuilder(connectionString);
			this.dbName = string.IsNullOrWhiteSpace(builder.InitialCatalog)?dbName: builder.InitialCatalog;
			if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(dbName)) throw new ArgumentException("invalid tbl");
		}
		public void Save(ReportInitializer reportInitializer)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("view_id", typeof(string));
			dt.Columns.Add("date_from", typeof(string));
			dt.Columns.Add("date_to", typeof(string));
			foreach (var dim in reportInitializer.Report.ColumnHeader.Dimensions)
			{
				dt.Columns.Add(dim, typeof(string));
			}
			foreach (var metr in reportInitializer.Report.ColumnHeader.MetricHeader.MetricHeaderEntries)
			{
				dt.Columns.Add(metr.Name, typeof(string));
			}
			foreach(var row in reportInitializer.Report.Data.Rows)
			{
				var dr = dt.NewRow();
				dr["view_id"] = reportInitializer.View.Id;
				dr["date_from"] = reportInitializer.DateStart;
				dr["date_to"] = reportInitializer.DateEnd;
				foreach (var dim in reportInitializer.Report.ColumnHeader.Dimensions)
				{
					dr[dim] = row.Dimensions.Where(x => x == dim).FirstOrDefault();
				}
				for (int i = 0; i < reportInitializer.Report.ColumnHeader.MetricHeader.MetricHeaderEntries.Count;i++)
				{
					var metr = reportInitializer.Report.ColumnHeader.MetricHeader.MetricHeaderEntries[i];
					dr[metr.Name] = row.Metrics[i].Values;
				}
				dt.SaveDataTable(connectionString, tableName, true, schemaName, dbName);
			}
			

		}
	}
}

using bi_dev.integration.utils.storage;
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
			this.dbName = string.IsNullOrWhiteSpace(dbName) ? builder.InitialCatalog: dbName;
			if (string.IsNullOrWhiteSpace(tableName) && string.IsNullOrWhiteSpace(this.dbName)) throw new ArgumentException("invalid tbl");
		}
		public void Save(GCustomReport report)
		{
			report.ToDataTable().SaveDataTable(new MsSqlWorker(connectionString, tableName, true, schemaName, dbName));
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace bi_dev.integration.utils.mssql
{
	public class MsSqlWorker : ISaveable
	{
		private string connectionString;
		private string dbTableName;
		private bool dropTableBeforeCopy;
		private string dbSchemaName;
		private string dbName;
		public MsSqlWorker(string connectionString, string dbTableName, bool dropTableBeforeCopy, string dbSchemaName = null, string dbName = null)
		{
			this.connectionString = connectionString;
			this.dropTableBeforeCopy = dropTableBeforeCopy;
			this.dbName = "[" + ((string.IsNullOrWhiteSpace(dbName)) ? new SqlConnectionStringBuilder(connectionString).InitialCatalog : dbName) + "]";
			if (string.IsNullOrWhiteSpace(this.dbName)) throw new ArgumentException("No db provided");
			this.dbSchemaName = "[" + ((string.IsNullOrWhiteSpace(dbSchemaName))?"dbo": dbSchemaName) + "]";
			this.dbTableName = "[" + dbTableName.Replace("[", "").Replace("]", "") + "]";

		}
		public void Save(DataTable dataTable)
		{
			using (SqlConnection connection = new SqlConnection(this.connectionString))
			{
				connection.Open();
				
				string tableName = $"{dbName.Replace("[", "").Replace("]", "")}.{dbSchemaName.Replace("[", "").Replace("]", "")}.{dbTableName.Replace("[", "").Replace("]", "")}";
				if (dropTableBeforeCopy)
				{
					string columnNames = "";
					for (int i = 0; i < dataTable.Columns.Count; i++)
					{
						columnNames = columnNames + ((i > 0) ? "," : "") + "[" + dataTable.Columns[i].ColumnName.Replace("[", "").Replace("]", "") + "]" + " nvarchar(max)";
					}

					string cmdText = string.Format(
						@"if object_id('{0}') is not null drop table {0};
                        create table {0}
                        (
                            {1}
                        );",
						tableName,
						columnNames
					);
					using (SqlCommand sc = new SqlCommand(cmdText, connection))
					{
						sc.ExecuteNonQuery();
					}
				}
				using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
				{
					foreach (DataColumn c in dataTable.Columns)
					{
						bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
					}
					bulkCopy.DestinationTableName = tableName;
					bulkCopy.WriteToServer(dataTable);

				}
			}
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;

namespace bi_dev.integration.utils.mssql
{
    public static class Extensions
    {
		public static void SaveDataTable(this DataTable dataTable, SqlConnection connection, string dbTableName, bool dropTableBeforeCopy, string dbSchemaName = null, string dbName = null)
		{
			using (connection)
			{
				connection.Open();
				dbName = (string.IsNullOrWhiteSpace(dbName)) ? connection.Database : dbName;
				if (string.IsNullOrWhiteSpace(dbName)) throw new ArgumentException("No db provided");
				if (string.IsNullOrWhiteSpace(dbSchemaName)) dbSchemaName = "dbo";
				string tableName = $"{dbName.Replace("[", "").Replace("]", "")}.{dbSchemaName.Replace("[", "").Replace("]", "")}.{dbTableName.Replace("[", "").Replace("]", "")}";
				if (dropTableBeforeCopy)
				{
					string columnNames = "";
					for (int i = 0; i < dataTable.Columns.Count; i++)
					{
						columnNames = columnNames + ((i > 0) ? "," : "") + dataTable.Columns[i].ColumnName + " nvarchar(max)";
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
		public static void SaveDataTable(this DataTable dataTable, string connectionString, string dbTableName, bool dropTableBeforeCopy, string dbSchemaName = null, string dbName = null)
		{
			SaveDataTable(dataTable, new SqlConnection(connectionString), dbTableName, dropTableBeforeCopy, dbSchemaName, dbName);
		}
	}
}

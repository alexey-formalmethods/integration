using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace bi_dev.integration.utils.storage.MsSql
{
	public class MsSqlDataTableStorageWorker : IStorageWorker<DataTable, MsSqlStorageInitializer>
	{
		public void Save(DataTable dataTable, MsSqlStorageInitializer initializer)
		{
            using (SqlConnection connection = new SqlConnection(initializer.ConnectionString))
			{
				connection.Open();
				
				string tableName = $"{initializer.DbName.Replace("[", "").Replace("]", "")}.{initializer.DbSchemaName.Replace("[", "").Replace("]", "")}.{initializer.DbTableName.Replace("[", "").Replace("]", "")}";
				if (initializer.DropTableBeforeCopy)
				{
					string columnNames = "";
					for (int i = 0; i < dataTable.Columns.Count; i++)
					{
                        // Если в конце навания колонки пробелы, заменим их на cимволы #
                        string colName = dataTable.Columns[i].ColumnName;
                        if (colName != colName.TrimEnd())
                        {
                            string newColNameStart = dataTable.Columns[i].ColumnName.TrimEnd();
                            colName = newColNameStart + colName.Replace(newColNameStart, "").Replace(" ", "#");
                            dataTable.Columns[i].ColumnName = colName;
                        }
                        columnNames = columnNames + ((i > 0) ? "," : "") + "[" + colName.Replace("[", "").Replace("]", "") + "] " + dataTable.Columns[i].DataType.GetSqlServerTypeName();
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
                        sc.CommandTimeout = connection.ConnectionTimeout;
						sc.ExecuteNonQuery();
					}
				}
				using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
				{
                    bulkCopy.BulkCopyTimeout = connection.ConnectionTimeout;

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

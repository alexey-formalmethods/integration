using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace bi_dev.integration.utils.storage.MsSql
{
    public class MsSqlStorageInitializer: IStorageInitializer
    {
        private string connectionString;
        public string ConnectionString { get { return this.connectionString; } }
        string dbTableName;
        public string DbTableName { get { return this.dbTableName; } }
        bool dropTableBeforeCopy;
        public bool DropTableBeforeCopy { get { return this.dropTableBeforeCopy; } }
        string dbSchemaName;
        public string DbSchemaName { get { return this.dbSchemaName; } }
        string dbName;
        public string DbName { get { return this.dbName; } }
        public MsSqlStorageInitializer(string connectionString, string dbTableName, bool dropTableBeforeCopy, string dbSchemaName = null, string dbName = null)
        {
            this.connectionString = connectionString;
            this.dropTableBeforeCopy = dropTableBeforeCopy;
            this.dbName = "[" + ((string.IsNullOrWhiteSpace(dbName)) ? new SqlConnectionStringBuilder(connectionString).InitialCatalog : dbName) + "]";
            if (string.IsNullOrWhiteSpace(this.dbName)) throw new ArgumentException("No db provided");
            this.dbSchemaName = "[" + ((string.IsNullOrWhiteSpace(dbSchemaName)) ? "dbo" : dbSchemaName) + "]";
            this.dbTableName = "[" + dbTableName.Replace("[", "").Replace("]", "") + "]";
        }
    }
}

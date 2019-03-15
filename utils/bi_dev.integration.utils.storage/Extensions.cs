using System;
using System.Data;
using System.Data.SqlClient;

namespace bi_dev.integration.utils.storage
{
    public static class Extensions
    {
		public static void SaveDataTable(this DataTable dataTable, ISaveable saveContext)
		{
			saveContext.Save(dataTable);
		}
	}
}

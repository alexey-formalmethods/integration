using bi_dev.integration.utils.storage;
using bi_dev.integration.utils.storage.MsSql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace bi_dev.integration.google.analytics.reporting.storage
{

	public class MsSqlReportSaver : IReportSaver 
    {
        IStorageWorker<DataTable, MsSqlStorageInitializer> worker;
        MsSqlStorageInitializer storageInitializer;
        public MsSqlReportSaver(IStorageWorker<DataTable, MsSqlStorageInitializer> worker, MsSqlStorageInitializer storageInitializer)
		{
            this.worker = worker;
            this.storageInitializer = storageInitializer;

        }
		public void Save(GCustomReport report)
		{
            this.worker.Save(report.ToDataTable(), storageInitializer);
		}
	}
}

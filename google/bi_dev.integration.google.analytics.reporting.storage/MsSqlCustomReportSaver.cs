using bi_dev.integration.utils;
using bi_dev.integration.utils.storage;
using bi_dev.integration.utils.storage.MsSql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace bi_dev.integration.reporting.storage
{
    

	public class MsSqlCustomReportSaver: ICustomReportSaver
    {
        MsSqlDataTableStorageWorker worker;
        MsSqlStorageInitializer storageInitializer;
        public MsSqlCustomReportSaver(MsSqlDataTableStorageWorker worker, MsSqlStorageInitializer storageInitializer)
		{
            this.worker = worker;
            this.storageInitializer = storageInitializer;
        }
		public void Save(ICustomReport report)
		{
            this.worker.Save(report.ToDataTable(), storageInitializer);
		}
    }
}

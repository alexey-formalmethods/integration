using bi_dev.integration.calltouch.reporting;
using bi_dev.integration.reporting.storage;
using bi_dev.integration.utils.storage.MsSql;
using Newtonsoft.Json;
using System;
using System.IO;

namespace bi_dev.integration.reporting.cnsl.calltouch
{
    class Program
    {
        static int Main(string[] args)
        {
            string tokensJsonPath = args[0];
            string connectionString = File.ReadAllText(args[1]);
            CTConfig ctConfig = new CTConfig
            {
                TokensJsonPath = tokensJsonPath
            };
            string siteId = args[2];
            string dateFrom = args[3];
            string dateTo = args[4];
            string[] columnNames = JsonConvert.DeserializeObject<string[]>(args[5]);
            string tblName = args[6];
            CTCustomReportManager ctm = new CTCustomReportManager(new CTRestCallsReportReceiver(ctConfig));
            var ctr = ctm.Get(new CTCustomReportInitializer(
                siteId,
                dateFrom,
                dateTo, 
                columnNames
            
            ));
            CustomReportStorageManager ctsm = new CustomReportStorageManager(
                new MsSqlCustomReportSaver(
                    new MsSqlDataTableStorageWorker(),
                    new MsSqlStorageInitializer(
                        connectionString,
                        tblName,
                        true,
                        "dbo"
                    )
                )
            );
            ctsm.Save(ctr);
            return 0;
        }
    }
}

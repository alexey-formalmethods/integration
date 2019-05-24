using bi_dev.integration.reporting.storage;
using bi_dev.integration.utils.storage.MsSql;
using bi_dev.integration.yandex.direct.reporting;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;

namespace bi_dev.integration.reporting.cnsl.yandex_direct
{
    class Program
    {
        static int Main(string[] args)
        {
            
            string credentialsJsonPath = args[0];
            string reportType = args[1];
            string[] columns = JsonConvert.DeserializeObject<string[]>(args[2]);
            string dateFormat = args[3];
            DateTime eventDate = DateTime.ParseExact(args[4], dateFormat, CultureInfo.CurrentCulture);
            string dbConnectionStringPath = File.ReadAllText(args[5]);
            string destTblName = args[6];
            
            var rep = new YDReportManager(
                new YDRestApi5CustomReportReceiver()
            ).Get(
                new YDCustomReportInitializer(
                    new YDConfig
                    {
                        CredentialsJsonPath = credentialsJsonPath
                    },
                    reportType,
                    eventDate,
                    eventDate,
                    columns, 
                    false
                )
            );
            
            CustomReportStorageManager gsrmsm = new CustomReportStorageManager(
                new MsSqlCustomReportSaver(
                    new MsSqlDataTableStorageWorker(),
                    new MsSqlStorageInitializer(dbConnectionStringPath, destTblName, true, "dbo")
                )
            );
            gsrmsm.Save(rep);
            return 0;
        }
    }
}

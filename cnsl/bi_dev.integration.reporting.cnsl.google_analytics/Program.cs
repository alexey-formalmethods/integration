using bi_dev.integration.google.analytics.reporting;
using bi_dev.integration.reporting.storage;
using bi_dev.integration.utils.storage.MsSql;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;

namespace bi_dev.integration.reporting.cnsl.google_analytics
{
    
    class Program
    {
        static int Main(string[] args)
        {
            string view_id = args[0];
            string dateFormat = args[1];
            string ga_day = args[2];
            DateTime event_day = DateTime.ParseExact(ga_day, dateFormat, CultureInfo.CurrentCulture);
            string metricStr = args[3];
            string[] metrics = string.IsNullOrWhiteSpace(metricStr) ? new string[0] : JsonConvert.DeserializeObject<string[]>(metricStr);
            string dimStr = args[4];
            string[] dimesnions = string.IsNullOrWhiteSpace(dimStr) ? new string [0] :JsonConvert.DeserializeObject<string[]>(dimStr);
            string credentialUserAccountJsonPath = args[5];
            string credentialServiceAccountJsonPath = args[6];
            string connectionString = File.ReadAllText(args[7]);
            string destinationTable = args[8];
            GCustomReportInitializer reportInitializer = new GCustomReportInitializer(
                new GView(view_id),
                event_day,
                metrics,
                dimesnions
            );
            GReportManager gaReportManager = new GReportManager(
                new GAnalyticsReportingV4CustomReportReciver(
                    new GConfig
                    {
                        CredentialUserAccountJsonPath = string.IsNullOrWhiteSpace(credentialUserAccountJsonPath)?null: credentialUserAccountJsonPath
                       ,CredentialServiceAccountJsonPath = string.IsNullOrWhiteSpace(credentialServiceAccountJsonPath) ? null : credentialServiceAccountJsonPath
                    }
                )
            );
            var re = gaReportManager.Get(reportInitializer);

            CustomReportStorageManager gsm = new CustomReportStorageManager(
                new MsSqlCustomReportSaver(
                    new MsSqlDataTableStorageWorker(),
                    new MsSqlStorageInitializer(connectionString, destinationTable, true, "dbo")
                )
            );
            gsm.Save(re);
            return 0;
        }
    }
}

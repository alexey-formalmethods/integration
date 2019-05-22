using bi_dev.integration.google.adwords.reporting;
using bi_dev.integration.reporting.storage;
using bi_dev.integration.utils.storage.MsSql;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;

namespace bi_dev.integration.reporting.cnsl.google_adwords
{
    class Program
    {
        static int Main(string[] args)
        {
            string credentialsJsonPath = args[0];
            string developerToken = File.ReadAllText(args[1]);
            string accountId = args[2];
            string reportType = args[3];
            string[] columns = JsonConvert.DeserializeObject<string[]>(args[4]);
            string dateFormat = args[5];
            DateTime dateFrom = DateTime.ParseExact(args[6], dateFormat, CultureInfo.CurrentCulture);
            string dbConnectionString = File.ReadAllText(args[7]);
            string tblName = args[8];
            //Console.WriteLine(string.IsNullOrWhiteSpace(dbConnectionString)?"FUCK NO Connection string": dbConnectionString);
            GADCustomReportManager p = new GADCustomReportManager(new ApiAdwrods201809CustomReportReceiver());
            var gadRep = p.Get(new GADCustomReportInitializer(
                new GADConfig {
                    CredentialsJsonPath = credentialsJsonPath,
                    DeveloperToken = developerToken
                },
                accountId,
                columns, //new string[] { "CampaignId", "Cost" },
                reportType, //"CAMPAIGN_PERFORMANCE_REPORT",
                dateFrom, //new DateTime(2019, 1, 1),
                dateFrom //new DateTime(2019, 5, 21)
            ));
            CustomReportStorageManager cmsm = new CustomReportStorageManager(
               new MsSqlCustomReportSaver(
                   new MsSqlDataTableStorageWorker(),
                   new MsSqlStorageInitializer(
                       dbConnectionString,
                       tblName,
                       true,
                       "dbo"
                   )
               )
            );
            cmsm.Save(gadRep);
            return 0;
        }
    }
}

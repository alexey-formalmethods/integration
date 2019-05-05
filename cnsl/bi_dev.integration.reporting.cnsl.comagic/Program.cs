using bi_dev.integration.comagic.reporting;
using bi_dev.integration.reporting.storage;
using bi_dev.integration.utils.storage.MsSql;
using Newtonsoft.Json;
using System;
using System.IO;

namespace bi_dev.integration.reporting.cnsl.comagic
{
    public class ComagicCnslConfig
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "connection_string")]
        public string DbConnectionString { get; set; }
    }
    class Program
    {
        static int Main(string[] args)
        {
            ComagicCnslConfig ccc = JsonConvert.DeserializeObject<ComagicCnslConfig>(File.ReadAllText(args[0]));
            string apiHost = args[1];
            string apiVer = args[2];
            string dateFormat = args[3];
            string reportType = args[4];
            string dateFrom = args[5];
            string dateTo = args[6];
            string [] columnNames = JsonConvert.DeserializeObject<string[]>(args[7]);
            string tableName = args[8];
            CMConfig cmConfig = new CMConfigWithAccessToken
                    (
                        ccc.AccessToken,
                        apiHost,
                        apiVer,
                        dateFormat
                    );
            CMCustomReportManager cmrm = new CMCustomReportManager(new CMCustomReportReceiver(cmConfig));
            var cmrep = cmrm.Get(new CMCustomReportInitializer(
                    cmConfig,
                    reportType,
                    dateFrom,
                    dateTo,
                    columnNames
                )
            );
            CustomReportStorageManager cmsm = new CustomReportStorageManager(
                new MsSqlCustomReportSaver(
                    new MsSqlDataTableStorageWorker(),
                    new MsSqlStorageInitializer(
                        ccc.DbConnectionString,
                        tableName,
                        true,
                        "dbo"
                    )
                )
            );
            cmsm.Save(cmrep);
            return 0;
        }
    }
}

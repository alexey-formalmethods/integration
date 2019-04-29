using bi_dev.integration.google.sheets.reporting;
using bi_dev.integration.reporting.storage;
using bi_dev.integration.utils.storage.MsSql;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bi_dev.integration.reporting.cnsl.google_sheet
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                string credentialsPath = args[0];
                string sheetId = args[1];
                string tabName = args[2];
                string diapasone = args[3];
                string columnNames = args[4]; // [["Партнер", "partner_ru_name"], ["CRM name", "crm_sell_point_name"]]
                string columnNamesWithAlter = args[5]; // [["Партнер", "partner_ru_name"], ["CRM name", "crm_sell_point_name"]]
                string[] parsedColumns = string.IsNullOrWhiteSpace(columnNames)?null:JsonConvert.DeserializeObject<string[]>(columnNames);
                string[][] parsedColumnsWithAlter = string.IsNullOrWhiteSpace(columnNamesWithAlter) ? null : JsonConvert.DeserializeObject<string[][]>(columnNamesWithAlter);
                KeyValuePair<string, string>[] argCols;
                if (parsedColumnsWithAlter != null && parsedColumnsWithAlter.Length > 0)
                {
                    argCols = parsedColumnsWithAlter.Select(x => new KeyValuePair<string, string>(x[0], x[1])).ToArray();
                }
                else if (columnNames != null && columnNames.Length > 0)
                {
                    argCols = parsedColumns.Select(x => new KeyValuePair<string, string>(x, x)).ToArray();
                }
                else
                {
                    argCols = new KeyValuePair<string, string>[0];
                }
                string destTable = args[6];
                string destSchema = args[7];
                string connectionString = File.ReadAllText(args[8]);
                // Google Sheet
                //string connectionString = "Data Source=localhost;Initial Catalog=localdb;Integrated Security=True;MultipleActiveResultSets=True";
                GSReportManager gsrm = new GSReportManager(new GSApiV4ReportReceiver(new GSConfig { CredentialServiceAccountJsonPath = credentialsPath }));
                var gsrep = gsrm.Get(new GSReportInitializer(
                        sheetId,
                        tabName,
                        diapasone,
                        argCols
                    )
                );
                CustomReportStorageManager gsrmsm = new CustomReportStorageManager(
                    new MsSqlCustomReportSaver(
                        new MsSqlDataTableStorageWorker(),
                        new MsSqlStorageInitializer(connectionString, destTable, true, destSchema)
                    )
                );
                gsrmsm.Save(gsrep);
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

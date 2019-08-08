using bi_dev.integration.google.auth;
using bi_dev.integration.reporting;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bi_dev.integration.google.sheets.reporting
{
    public class GSApiV4ReportReceiver: IGSReportReceiver
    {
        private GSConfig config;
        public GSApiV4ReportReceiver(GSConfig config)
        {
            this.config = config;
        }
        public GSReport Get(GSReportInitializer initializer)
        {
            GSReport report = new GSReport(initializer);
            if (initializer.Columns == null || initializer.Columns.Count == 0)
            {
                initializer.Columns = new Dictionary<string, CustomReportColumn>();
            }
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = new GCommonCredentialManager<GServiceAccountFileCredentialReceiver, GServiceAccountFileCredentialInitializer>().Get(new GServiceAccountFileCredentialInitializer(
                    this.config.CredentialServiceAccountJsonPath, 
                    new string[] { "https://www.googleapis.com/auth/spreadsheets.readonly" }
                )).GoogleCredential, // credential,
                ApplicationName = "bi-dev-data-collector",
            });

            // Define request parameters.
            string spreadsheetId = initializer.SheetId;
            string range = $"{initializer.TabName}!{ initializer.Diapasone}";// "Sheet1!A:B";
            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(spreadsheetId, range);
            // request.MajorDimension = SpreadsheetsResource.ValuesResource.GetRequest.MajorDimensionEnum.DIMENSIONUNSPECIFIED;
            // request.ValueRenderOption = SpreadsheetsResource.ValuesResource.GetRequest.ValueRenderOptionEnum.FORMATTEDVALUE;
            // 
            // https://docs.google.com/spreadsheets/d/11WyHxWRfxSkrUKDtsJCpmLAeG4cv9yKJ7NYKsWx2bwY/edit
            ValueRange response = request.Execute();
            IList<IList<object>> values = response.Values;
            HashSet<int> requrequiredColumns = new HashSet<int>();

            if (values != null && values.Count > 0)
            {
                for(int i = 0; i < values[0].Count;i++)
                {
                    var gsCol = values[0][i].ToString();
                    
                    if (initializer.Columns.ContainsKey(gsCol) || initializer.AllColumns) requrequiredColumns.Add(i);
                    if (initializer.AllColumns) initializer.Columns.Add(gsCol, new GSReportColumn(typeof(string), gsCol, gsCol));
                   
                }
                if (values.Count > 1)
                {
                    report.Rows = new List<CustomReportRow>();
                    for (int i = 1; i < values.Count; i++)
                    {
                        List<CustomReportCell> cells = new List<CustomReportCell>();

                        for (int j = 0; j < values[i].Count; j++)
                        {
                            if (requrequiredColumns.Contains(j))
                            {
                                cells.Add(new CustomReportCell(initializer.Columns[values[0][j].ToString()], values[i][j].ToString()));
                            }
                        }
                        report.Rows.Add(new CustomReportRow(cells));
                    }
                }
            }
            return report;
        }
    }
}

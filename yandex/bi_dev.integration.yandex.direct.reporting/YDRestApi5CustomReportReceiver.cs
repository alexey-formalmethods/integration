using bi_dev.integration.reporting;
using bi_dev.integration.yandex.auth;
using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using RestSharp;

namespace bi_dev.integration.yandex.direct.reporting
{
    public class YDRestApi5CustomReportReceiver : ICustomReportReceiver<YDCustomReport, YDCustomReportInitializer>
    {
        public YDCustomReport Get(YDCustomReportInitializer initializer)
        {
            try
            {
                YCommonCredentialManager cm = new YCommonCredentialManager();
                var credentials = cm.Get(new YRestCredentialInitializer(initializer.Config.CredentialsJsonPath));
                
                RestClient rc = new RestClient();
                RestRequest rr = new RestRequest(Constants.RestApi5Url, Method.POST);
                rr.AddHeader("Authorization", $"Bearer {credentials.AccessToken}");
                rr.AddHeader("processingMode", "auto");
                rr.AddHeader("returnMoneyInMicros", "true");
                rr.AddHeader("skipReportHeader", "true");
                rr.AddHeader("skipReportSummary", "true");


                WebClient wc = new WebClient();
                wc.Headers[HttpRequestHeader.Authorization] = $"Bearer {credentials.AccessToken}";
                wc.Headers["processingMode"] = "auto";
                wc.Headers["returnMoneyInMicros"] = "true";
                wc.Headers["skipReportHeader"] = "true";
                wc.Headers["skipReportSummary"] = "true";

                rest.YDRestApi5ReportRequest apiRequest = new rest.YDRestApi5ReportRequest
                {
                    Params = new rest.YDRestApi5ReportRequestParams
                    {
                        SelectionCriteria = new rest.YDRestApi5ReportRequestParamsSelectionCriteria
                        {
                            DateFrom = initializer.DateFrom.ToString(Constants.RestApi5DateFormat),
                            DateTo = initializer.DateTo.ToString(Constants.RestApi5DateFormat)
                        },
                        FieldNames = initializer.Columns.Select(x => x.Value.Name).ToArray(),
                        IncludeVAT = initializer.IncludeVAT,
                        ReportType = initializer.ReportType
                    }
                };
                Console.WriteLine("ReportName: " + apiRequest.Params.ReportName);
                var body = JsonConvert.SerializeObject(apiRequest);
                rr.AddParameter("application/json", body, ParameterType.RequestBody);
                //wc.UploadString(Constants.RestApi5Url, JsonConvert.SerializeObject(apiRequest));
                var response = rc.Execute(rr);
                Encoding encoding = Encoding.Unicode;
                string tSvResult = encoding.GetString(response.RawBytes);
                var report = new YDCustomReport(initializer, false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    report.IsReady = true;
                    using (TextReader r = new StringReader(tSvResult))
                    {
                        //r.ReadLine(); // !! skip 1-st row with shit data !!
                        using (CsvReader cr = new CsvReader(r))
                        {
                            cr.Configuration.Delimiter = "\t";
                            using (var dr = new CsvDataReader(cr))
                            {
                                DataTable dt = new DataTable();
                                dt.Load(dr);
                                DataRow[] tblRows = dt.Rows.Cast<DataRow>().ToArray();
                                report.Rows = tblRows.Select(x => new CustomReportRow(
                                        x.Table.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => x[c]).Where(t => initializer.Columns.ContainsKey(t.Key)).Select(y => new CustomReportCell(initializer.Columns[y.Key], y.Value.ToString())).ToArray()
                                    )
                                ).ToArray();

                            }
                        }
                    }
                }
                else if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.Created)
                {
                    report.IsReady = false;
                }
                else
                {
                    throw new Exception(response.Content);
                }
                return report;
            }
            catch (WebException ex)
            {
                using (StreamReader sr = new StreamReader(ex.Response.GetResponseStream()))
                {
                    var resp = sr.ReadToEnd();
                    throw new Exception(resp);
                }
                

            }
        }
    }
}

using bi_dev.integration.calltouch.auth;
using bi_dev.integration.reporting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace bi_dev.integration.calltouch.reporting
{
    public class CTRestCallsReportReceiver : ICTCustomReportReceiver
    {
        CTConfig config;
        public CTRestCallsReportReceiver(CTConfig config)
        {
            this.config = config;
        }
        public CTCustomReport Get(CTCustomReportInitializer initializer)
        {
            CTCustomReport report = new CTCustomReport(initializer)
            {
                Rows = new List<CustomReportRow>()
            };
            WebClient wc = new WebClient();
            var credentials = new CTCommonCredentialManager().Get(new CTFileCredentialsInitializer(config.TokensJsonPath)).CredentialDictionary[initializer.SiteId];
            string url = $"{credentials.Host}/calls-service/RestAPI/{credentials.SiteId}/calls-diary/calls?clientApiId={credentials.AccessToken}&dateFrom={initializer.DateFrom.ToString(CTConstants.ApiDateFormat)}&dateTo={initializer.DateTo.ToString(CTConstants.ApiDateFormat)}";
            //Console.WriteLine(url);
            //Console.WriteLine(CTConstants.ApiDateFormat);
            string resultString = wc.DownloadString(url);
            var result = JsonConvert.DeserializeObject<ICollection<Dictionary<string, object>>>(resultString);
            report.Rows = result?.Select(x => new CustomReportRow
            {
                Cells = x.Where(t=>initializer.Columns.ContainsKey(t.Key) || initializer.NoColumnsPassed).Select(t => {
                    if (initializer.NoColumnsPassed && (!initializer.Columns.ContainsKey(t.Key)))
                    {
                        initializer.Columns.Add(t.Key, new CTCustomReportColumn(t.Key));
                    }
                    return new CustomReportCell(initializer.Columns[t.Key], (t.Value != null && (t.Value.GetType().IsClass && t.Value.GetType() != typeof(string) || t.Value.GetType().IsArray)) ? JsonConvert.SerializeObject(t.Value) : t.Value?.ToString());
                }).ToArray()
            }).ToArray();
            return report;
        }
    }
}

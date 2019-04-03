using bi_dev.integration.calltouch.auth;
using bi_dev.integration.reporting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            var credentials = CTCommonCredentialManager.Get(new CTFileCredentialsInitializer(config.TokensJsonPath));
            string resultString = wc.DownloadString($"{config.ApiUrl}/calls-service/RestAPI/{credentials.SiteId}/calls-diary/calls?clientApiId={credentials.AccessToken}&dateFrom={initializer.DateFrom.ToString(CTConstants.InputDateFormat)}&dateTo={initializer.DateTo.ToString(CTConstants.InputDateFormat)}");
            var result = JsonConvert.DeserializeObject<ICollection<Dictionary<string, object>>>(resultString);
            foreach(var dict in result)
            {
                report.Rows.Add(
                    new CustomReportRow(
                        dict.Select(x => new CTCustomReportCell(x.Key, JsonConvert.SerializeObject(x.Value))).ToArray()
                    )
                );
            }
            return report;
        }
    }
}

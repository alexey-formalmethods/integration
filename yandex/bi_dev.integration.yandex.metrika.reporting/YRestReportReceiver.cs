using bi_dev.integration.reporting;
using bi_dev.integration.yandex.auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public class YRestReportReceiver : ICustomReportReceiver<YCustomReport, YReportInitializer>
    {
        YConfig config;
        public YRestReportReceiver(YConfig config)
        {
            this.config = config;
        }
        public YCustomReport Get(YReportInitializer initializer)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add(
                "Authorization",
                $"OAuth {YCommonCredentialManager.Get(new YRestCredentialInitializer(config.TokensJsonPath)).AccessToken}"
            );

            string url = $"{ config.ApiUrl}stat/v1/data?ids={initializer.Counter.Id.ToString()}" +
                $"&date1={initializer.DateStart.ToString("yyyy-MM-dd")}" +
                $"&date2={initializer.DateEnd.ToString("yyyy-MM-dd")}" +
                $"&metrics={string.Join(",", initializer.Metrics.Select(x => x.Name).ToArray())}" +
                $"&dimensions={string.Join(",", initializer.Dimensions.Select(x => x.Name).ToArray())}";
            string result = wc.DownloadString(url);
            ReportRestResponse apiReport = JsonConvert.DeserializeObject<ReportRestResponse>(result);
            YCustomReport customReport = new YCustomReport(initializer)
            {
                Rows = new List<CustomReportRow>()
            };

            foreach (var row in apiReport.Rows)
            {
                List<CustomReportCell> reportRowCells = new List<CustomReportCell>();
                for (int i = 0; i < apiReport.Request.Dimensions.Length; i++)
                {
                    reportRowCells.Add(new YCustomDimensionValued(apiReport.Request.Dimensions[i], row.Dimensions[i].Name));
                }
                for (int i = 0; i < apiReport.Request.Metrics.Length; i++)
                {
                    reportRowCells.Add(new YCustomMetricValued(apiReport.Request.Metrics[i], row.Metrics[i].ToString()));
                }
                customReport.Rows.Add(new CustomReportRow(reportRowCells));
            }
            return customReport;

        }
    }
}

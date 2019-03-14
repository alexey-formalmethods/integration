using bi_dev.integration.yandex.auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
	public class ReportInitializerRest : BaseReportInitializer
	{
		public ReportInitializerRest(Config config, Counter counter, ICollection<CustomDimension> dimensions, ICollection<CustomMetric> metrics, DateTime dateStart) : base(config, counter, dimensions, metrics, dateStart)
		{
		}

		public override CustomReport Get()
		{
			WebClient wc = new WebClient();
			wc.Headers.Add(
				"Authorization", 
				$"OAuth {CommonCredentialManager.Get(new RestCredentialInitializer(config.TokensJsonPath)).AccessToken}"
			);
			
			string url = $"{ config.ApiUrl}stat/v1/data?ids={this.Counter.Id.ToString()}" +
				$"&date1={this.DateStart.ToString("yyyy-MM-dd")}" +
				$"&date2={this.DateEnd.ToString("yyyy-MM-dd")}" +
				$"&metrics={string.Join(",", this.Metrics.Select(x=>x.Name).ToArray())}" +
				$"&dimensions={string.Join(",", this.Dimensions.Select(x => x.Name).ToArray())}";
			string result = wc.DownloadString(url);
			ReportRestResponse apiReport = JsonConvert.DeserializeObject<ReportRestResponse>(result);
			CustomReport customReport = new CustomReport(this)
			{
				Rows = new List<CustomReportRow>()
			}; 

			foreach (var row in apiReport.Rows)
			{
				List<ICustomParameterValued> reportRowCells = new List<ICustomParameterValued>();
				for (int i = 0; i < apiReport.Request.Dimensions.Length; i++)
				{
					reportRowCells.Add(new CustomDimensionValued(apiReport.Request.Dimensions[i], row.Dimensions[i].Name));
				}
				for (int i = 0; i < apiReport.Request.Metrics.Length; i++)
				{
					reportRowCells.Add(new CustomMetricValued(apiReport.Request.Metrics[i], row.Metrics[i].ToString()));
				}
				customReport.Rows.Add(new CustomReportRow(reportRowCells));
			}
			return customReport;

		}
	}
}

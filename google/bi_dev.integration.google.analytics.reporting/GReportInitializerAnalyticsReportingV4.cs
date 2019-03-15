using bi_dev.integration.google.auth;
using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.AnalyticsReporting.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{

	public class GReportInitializerAnalyticsReportingV4 : GBaseReportInitializer
	{
		public GReportInitializerAnalyticsReportingV4(GConfig config, GView view, ICollection<GCustomDimension> dimensions, ICollection<GCustomMetric> metrics, DateTime dateStart) : base(config, view, dimensions, metrics, dateStart)
		{
		}
		
		public override GCustomReport Get()
		{

			var credetials = GoogleCredentialManager.GetCredentials(config.CredentialServiceAccountJsonPath, GConstants.Scopes);
			DateRange dateRange = new DateRange
			{
				StartDate = DateStart.ToString(GConstants.DateParamFormat),
				EndDate = DateEnd.ToString(GConstants.DateParamFormat)
			};

			// Create the Metrics object.
			//Metric sessions = new Metric { Expression = "ga:sessions", Alias = "Sessions" };

			//Create the Dimensions object.
			//Dimension browser = new Dimension { Name = "ga:browser" };

			// Create the ReportRequest object.
			ReportRequest reportRequest = new ReportRequest
			{
				ViewId = View.Id,
				DateRanges = new List<DateRange>() { dateRange },
				Dimensions = this.Dimensions.Select(x=>new Dimension { Name = x.Name }).ToList(),
				Metrics = this.Metrics.Select(x=>new Metric { Expression = x.Name, Alias = x.Name }).ToList()
			};

			List<ReportRequest> requests = new List<ReportRequest>
			{
				reportRequest
			};

			// Create the GetReportsRequest object.
			GetReportsRequest getReport = new GetReportsRequest() { ReportRequests = requests };

			// Call the batchGet method.
			AnalyticsReportingService s = new AnalyticsReportingService(new Google.Apis.Services.BaseClientService.Initializer { HttpClientInitializer = credetials });
			GetReportsResponse response = s.Reports.BatchGet(getReport).Execute();
			GCustomReport customReport = new GCustomReport(this)
			{
				Rows = new List<CustomReportRow>()
			};
			var apiReport = response.Reports.FirstOrDefault();
			
			foreach (var row in apiReport.Data.Rows)
			{
				List<IGCustomParameterValued> reportRowCells = new List<IGCustomParameterValued>();
				for (int i = 0; i < apiReport.ColumnHeader.Dimensions.Count; i++)
				{
					reportRowCells.Add(new GCustomDimensionValued(apiReport.ColumnHeader.Dimensions[i], row.Dimensions[i]));
				}
				for (int i = 0; i < apiReport.ColumnHeader.MetricHeader.MetricHeaderEntries.Count; i++)
				{
					reportRowCells.Add(new GCustomMetricValued(apiReport.ColumnHeader.MetricHeader.MetricHeaderEntries[i].Name, row.Metrics.FirstOrDefault().Values[i]));
				}
				customReport.Rows.Add(new CustomReportRow(reportRowCells));
			}
			return customReport;
		}
	}
}

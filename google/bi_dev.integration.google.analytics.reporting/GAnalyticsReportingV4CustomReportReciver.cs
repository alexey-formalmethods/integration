using bi_dev.integration.google.auth;
using bi_dev.integration.reporting;
using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.AnalyticsReporting.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{

	public class GAnalyticsReportingV4CustomReportReciver : IGCustomReportReceiver
	{
		
		
		public GCustomReport Get(GCustomReportInitializer initializer)
		{

			var credetials = GServiceAccountCredentialManager.GetCredentials(initializer.Config.CredentialServiceAccountJsonPath, GConstants.Scopes);
			DateRange dateRange = new DateRange
			{
				StartDate = initializer.DateStart.ToString(GConstants.DateParamFormat),
				EndDate = initializer.DateEnd.ToString(GConstants.DateParamFormat)
			};

			// Create the Metrics object.
			//Metric sessions = new Metric { Expression = "ga:sessions", Alias = "Sessions" };

			//Create the Dimensions object.
			//Dimension browser = new Dimension { Name = "ga:browser" };

			// Create the ReportRequest object.
			ReportRequest reportRequest = new ReportRequest
			{
				ViewId = initializer.View.Id,
				DateRanges = new List<DateRange>() { dateRange },
				Dimensions = initializer.Dimensions.Select(x=>new Dimension { Name = x.Name }).ToList(),
				Metrics = initializer.Metrics.Select(x=>new Metric { Expression = x.Name, Alias = x.Name }).ToList()
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
			GCustomReport customReport = new GCustomReport(initializer)
			{
				Rows = new List<CustomReportRow>()
			};
			var apiReport = response.Reports.FirstOrDefault();
            if (apiReport?.Data?.Rows != null)
            {
                foreach (var row in apiReport.Data.Rows)
                {
                    List<CustomReportCell> reportRowCells = new List<CustomReportCell>();
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
            }
			return customReport;
		}
    }
}

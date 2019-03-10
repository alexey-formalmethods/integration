using bi_dev.integration.google.auth;
using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.AnalyticsReporting.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
	
	public class ReportInitializer
    {
		private Config config;

		public ICollection<Dimension> Dimensions { get; set; } 
		public ICollection<Metric> Metrics { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime DateEnd { get; set; }
		public View View { get; set; }

		private Report report;
		public Report Report
		{
			get
			{
				if (this.report == null)
				{
					this.report = Get();
				}
				return this.report;
			}
		}
		public ReportInitializer(Config config, View view, ICollection<Dimension> dimensions, ICollection<Metric> metrics, DateTime dateStart)
		{
			this.config = config;
			this.View = view;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateStart;
		}
		public ReportInitializer(Config config, View view, ICollection<Dimension> dimensions, ICollection<Metric> metrics, DateTime dateStart, DateTime dateEnd)
		{
			this.config = config;
			this.View = view;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateEnd;
		}

		public Report Get()
		{
			var credetials = CredentialManager.GetCredentials(config.CredentialServiceAccountJsonPath, Constants.Scopes);
			DateRange dateRange = new DateRange() { StartDate = DateStart.ToString(Constants.DateParamFormat), EndDate = DateEnd.ToString(Constants.DateParamFormat) };

			// Create the Metrics object.
			Metric sessions = new Metric { Expression = "ga:sessions", Alias = "Sessions" };

			//Create the Dimensions object.
			Dimension browser = new Dimension { Name = "ga:browser"};

			// Create the ReportRequest object.
			// Create the ReportRequest object.
			ReportRequest reportRequest = new ReportRequest
			{
				ViewId = View.Id,
				DateRanges = new List<DateRange>() { dateRange },
				Dimensions = this.Dimensions.ToList(),
				Metrics = this.Metrics.ToList()
			};

			List<ReportRequest> requests = new List<ReportRequest>
			{
				reportRequest
			};

			// Create the GetReportsRequest object.
			GetReportsRequest getReport = new GetReportsRequest() { ReportRequests = requests };

			// Call the batchGet method.
			Google.Apis.AnalyticsReporting.v4.AnalyticsReportingService s = new AnalyticsReportingService(new Google.Apis.Services.BaseClientService.Initializer { HttpClientInitializer = credetials });
			GetReportsResponse response = s.Reports.BatchGet(getReport).Execute();
			return response.Reports.FirstOrDefault();
		}
	}
}

using bi_dev.integration.google.analytics.reporting;
using bi_dev.integration.google.analytics.reporting.storage;
using Google.Apis.AnalyticsReporting.v4.Data;
using System;

namespace bi_dev.integration.google.auth.Cnsl
{
    class Program
    {
        static void Main(string[] args)
        {
			BaseReportInitializer reportInitializer = new ReportInitializerAnalyticsReportingV4(
				new Config { CredentialServiceAccountJsonPath = @"C:\a.shamshur\public_projects\integration\common_credentials\google\bi-dev-001-06eaf0f926da.json" },
				new View("ga:191261391"),
				new CustomDimension[]
				{
					new CustomDimension("ga:browser"),
					new CustomDimension("ga:source")
				},
				new CustomMetric[]
				{
					new CustomMetric("ga:sessions"),
					new CustomMetric("ga:users")
				},
				new DateTime(2019, 3, 11)
			);
			ReportManager manager = new ReportManager(reportInitializer);
			var rep = manager.Get();
			string connectionString = "Data Source=localhost;Initial Catalog=localdb;Integrated Security=True;MultipleActiveResultSets=True";
			rep.SaveToMsSql(new MsSqlReportSaver(connectionString, "t_stg_ga_data", "dbo"));


		}
    }
}

using bi_dev.integration.google.analytics.reporting;
using bi_dev.integration.google.analytics.reporting.storage;
using bi_dev.integration.yandex.auth;
using bi_dev.integration.yandex.metrika.reporting;
using Google.Apis.AnalyticsReporting.v4.Data;
using System;

namespace bi_dev.integration.reporting.Cnsl
{
    class Program
    {
        static void Main(string[] args)
        {
			// GA download and store in MS SQL

			GBaseReportInitializer reportInitializer = new GReportInitializerAnalyticsReportingV4(
				new GConfig { CredentialServiceAccountJsonPath = @"C:\a.shamshur\public_projects\integration\common_credentials\google\bi-dev-001-06eaf0f926da.json" },
				new GView("ga:191261391"),
				new GCustomDimension[]
				{
					new GCustomDimension("ga:browser"),
					new GCustomDimension("ga:source")
				},
				new GCustomMetric[]
				{
					new GCustomMetric("ga:sessions"),
					new GCustomMetric("ga:users")
				},
				new DateTime(2019, 3, 11)
			);
			GReportManager manager = new GReportManager(reportInitializer);
			var rep = manager.Get();
			string connectionString = "Data Source=localhost;Initial Catalog=localdb;Integrated Security=True;MultipleActiveResultSets=True";
			rep.SaveToMsSql(new MsSqlReportSaver(connectionString, "t_stg_ga_data", "dbo"));
			


			var token = YCommonCredentialManager.Get(new RestCredentialInitializer(@"C:\a.shamshur\public_projects\integration\common_credentials\yandex\bi-dev-credentials.json"));
			yandex.metrika.reporting.YReportInitializerRest initializer = new YReportInitializerRest(
				new yandex.metrika.reporting.YConfig
				{
					TokensJsonPath = @"C:\a.shamshur\public_projects\integration\common_credentials\yandex\bi-dev-credentials.json",
					ApiUrl = "https://api-metrika.yandex.net/"
				}, 
				new YCounter { Id = 52783963 },
				new YCustomDimension[] { new YCustomDimension("ym:s:UTMSource") },
				new YCustomMetric [] {new YCustomMetric("ym:s:visits") },
				new DateTime(2019,3,14)
			);
			bi_dev.integration.yandex.metrika.reporting.YReportManager m = new yandex.metrika.reporting.YReportManager(initializer);
			var r = m.Get();
			
		}
    }
}

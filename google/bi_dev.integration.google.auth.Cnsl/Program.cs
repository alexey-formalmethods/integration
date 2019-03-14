//using bi_dev.integration.google.analytics.reporting;
using bi_dev.integration.google.analytics.reporting.storage;
using bi_dev.integration.yandex.auth;
using bi_dev.integration.yandex.metrika.reporting;
using Google.Apis.AnalyticsReporting.v4.Data;
using System;

namespace bi_dev.integration.google.analytics.Cnsl
{
    class Program
    {
        static void Main(string[] args)
        {
			// GA download and store in MS SQL
			/*
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
			*/
			var token = CommonCredentialManager.Get(
				new RestCredentialInitializer(
					"1:b60pvAhv73A8zpdO:QYRrLR0c39UL_AkVm9Rfgbv3B3KT0oiUC_ob8wXeFMVzslvYZFql:En50CBdZFDdWlLWFVSNoFw",
					"b9a182be0aa946b09e0937b2639798cb",
					"dc281b759fba4be8aaa59aea975e61c0"
				)
			);
			ReportInitializerRest initializer = new ReportInitializerRest(
				new yandex.metrika.reporting.Config
				{
					TokensJsonPath = @"C:\a.shamshur\public_projects\integration\common_credentials\yandex\bi-dev-credentials.json",
					ApiUrl = "https://api-metrika.yandex.net/"
				}, 
				new Counter { Id = 52783963 },
				new CustomDimension[] { new CustomDimension("ym:s:UTMSource") },
				new CustomMetric [] {new CustomMetric("ym:s:visits") },
				new DateTime(2019,3,14)
			);
			bi_dev.integration.yandex.metrika.reporting.ReportManager m = new yandex.metrika.reporting.ReportManager(initializer);
			var r = m.Get();
		}
    }
}

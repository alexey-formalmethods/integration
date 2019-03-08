using bi_dev.integration.google.analytics.reporting;
using Google.Apis.AnalyticsReporting.v4.Data;
using System;

namespace bi_dev.integration.google.auth.Cnsl
{
    class Program
    {
        static void Main(string[] args)
        {
			ReportInitializer reportInitializer = new ReportInitializer(
				new Config { CredentialServiceAccountJsonPath = @"C:\a.shamshur\public_projects\integration\credentials\ga\bi-dev-001-06eaf0f926da.json" },
				new View("ga:191261391"),
				new Dimension[]
				{
					new Dimension{Name = "ga:browser"}
				},
				new Metric[]
				{
					new Metric {Expression = "ga:sessions", Alias = "Sessions"}
				},
				new DateTime(2019, 1, 1)
			);
			var rep = reportInitializer.Get();


		}
    }
}

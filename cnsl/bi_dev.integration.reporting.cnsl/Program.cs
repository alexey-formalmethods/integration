using bi_dev.integration.calltouch.reporting;
using bi_dev.integration.google.adwords.reporting;
using bi_dev.integration.google.analytics.reporting;
using bi_dev.integration.google.analytics.reporting.storage;
using bi_dev.integration.reporting.storage;
using bi_dev.integration.utils.storage.MsSql;
using bi_dev.integration.yandex.auth;
using bi_dev.integration.yandex.metrika.reporting;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Google.Apis.AnalyticsReporting.v4.Data;
using System;
using System.Collections.Generic;

namespace bi_dev.integration.reporting.Cnsl
{
    class Program
    {
        static void Main(string[] args)
        {
            /*   
               var container = new WindsorContainer();
               container.Register(Component.For<GReportManager>());
               container.Register(Component.For<IGCustomReportReceiver>()
                   .ImplementedBy<GAnalyticsReportingV4CustomReportReciver>());

               // GA download and store in MS SQL

               GCustomReportInitializer reportInitializer = new GCustomReportInitializer(
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
                   new DateTime(2019, 3, 14)
               );

               var reportManager = container.Resolve<GReportManager>();
               container.Release(reportManager);
               var re = reportManager.Get(reportInitializer);
               string connectionString = "Data Source=localhost;Initial Catalog=localdb;Integrated Security=True;MultipleActiveResultSets=True";
               //rep.SaveToMsSql(new MsSqlReportSaver(connectionString, "t_stg_ga_data", "dbo"));
               ReportStorageManager m = new ReportStorageManager(
                   new MsSqlReportSaver(
                       new MsSqlDataTableStorageWorker(),
                       new MsSqlStorageInitializer(connectionString, "t_stg_ga_data", true, "dbo")
                   )
               );
               m.Save(re);
               */
            // YANDEX
            /*
			var token = YCommonCredentialManager.Get(new RestCredentialInitializer(@"C:\a.shamshur\public_projects\integration\common_credentials\yandex\bi-dev-credentials.json"));
			YReportInitializer initializer = new YReportInitializer(
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
			YReportManager m = new YReportManager(new YRestReportReceiver());
			var r = m.Get(initializer);
            CustomReportStorageManager sm = new CustomReportStorageManager(
                new MsSqlCustomReportSaver(
                    new MsSqlDataTableStorageWorker(),
                    new MsSqlStorageInitializer(
                        "Data Source=localhost;Initial Catalog=localdb;Integrated Security=True;MultipleActiveResultSets=True",
                        "t_stg_yd_data",
                        true,
                        "dbo"
                    )
                )
            );
            sm.Save(r);
            */
            //ADWORDS
            /*
            GADCustomReportManager p = new GADCustomReportManager(new ApiAdwrods201809CustomReportReceiver());
            var e = p.Get(new GADCustomReportInitializer
            {
                Account = new GADAccount("xxx-xxx-xxxx"),
                Columns = new GADCustomColumn[] { new GADCustomColumn("CampaignId"), new GADCustomColumn("Cost") },
                Type = new GADCustomReportType(GADReportTypeEnum.CAMPAIGN_PERFORMANCE_REPORT),
                DateStart = new DateTime(2019,1,1),
                DateEnd = new DateTime(2019,2,1),
                Config = new GADConfig
                {
                    
                }
            });
            */
            CTConfig ctConfig = new CTConfig
            {
                ApiUrl = "http://api.calltouch.ru",
                TokensJsonPath = @"C:\a.shamshur\public_projects\integration\common_credentials\calltouch\credentials-28466.json"

            };
            CTCustomReportManager m = new CTCustomReportManager(new CTRestCallsReportReceiver(ctConfig));
            var rep = m.Get(new CTCustomReportInitializer(
                new DateTime(2019, 1, 1),
                new DateTime(2019, 1, 2),
                new CTCustomReportColumn[]
                {
                    new CTCustomReportColumn("date"),
                    new CTCustomReportColumn("source"),
                    new CTCustomReportColumn("yaClientId")
                }
            ));
            var dt = rep.ToDataTable();
        }
    }
}

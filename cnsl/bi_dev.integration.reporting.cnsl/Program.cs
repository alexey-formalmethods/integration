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
using bi_dev.integration.google.sheets.reporting;
using bi_dev.integration.comagic.reporting;

namespace bi_dev.integration.reporting.Cnsl
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=localdb;Integrated Security=True;MultipleActiveResultSets=True";
            /*
            // Comagic https://dataapi.comagic.ru/v2.0

            CMCustomReportManager cmrm = new CMCustomReportManager(
                new CMCustomReportReceiver(
                    new CMConfigWithCredentailsPath
                    (
                        @"C:\a.shamshur\public_projects\integration\common_credentials\comagic\credentials.json",
                        "https://dataapi.comagic.ru",
                        "v2.0",
                        "yyyy-MM-dd HH:mm:ss"
                    )
                )
            );
            var cmrep = cmrm.Get(new CMCustomReportInitializer(
                    "communications_report",
                    new DateTime(2019,1,1),
                    new DateTime(2019, 1, 2), 
                    new string[]
                    {
                         "id"
                        ,"communication_type"
                        ,"communication_number"
                        ,"date_time"
                        ,"ua_client_id"
                        ,"ym_client_id"
                        ,"sale_date"
                        ,"sale_cost"
                        ,"search_query"
                        ,"search_engine"
                        ,"referrer_domain"
                        ,"referrer"
                        ,"entrance_page"
                        ,"gclid"
                        ,"yclid"
                        ,"ymclid"
                        ,"ef_id"
                        ,"channel"
                        ,"tags"
                        ,"site_id"
                        ,"site_domain_name"
                        ,"campaign_id"
                        ,"campaign_name"
                        ,"visit_other_campaign"
                        ,"visitor_id"
                        ,"person_id"
                        ,"visitor_type"
                        ,"visitor_session_id"
                        ,"visits_count"
                        ,"visitor_first_campaign_id"
                        ,"visitor_first_campaign_name"
                        ,"visitor_city"
                        ,"visitor_region"
                        ,"visitor_country"
                        ,"visitor_device"
                        ,"visitor_custom_properties"
                        ,"segments"
                        ,"utm_source"
                        ,"utm_medium"
                        ,"utm_term"
                        ,"utm_content"
                        ,"utm_campaign"
                        ,"openstat_ad"
                        ,"openstat_campaign"
                        ,"openstat_service"
                        ,"openstat_source"
                        ,"attributes"
                    }
                )
            );
            CustomReportStorageManager cmsm = new CustomReportStorageManager(
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
            cmsm.Save(cmrep);


            // Google Sheet
            
            GSReportManager gsrm = new GSReportManager(new GSApiV4ReportReceiver(new GSConfig { CredentialServiceAccountJsonPath = @"C:\a.shamshur\public_projects\integration\common_credentials\google\bi-dev-001-06eaf0f926da.json" }));
            var gsrep = gsrm.Get(new GSReportInitializer(
                    "1h2yzyTI7dPFTe1aid7IVxyhNGrMTL1ARX0mVZIdc5qM",
                    "Лист1",
                    "B2:M",
                    new KeyValuePair<string, string> [] {
                        new KeyValuePair<string, string>("Партнер", "partner_ru_name"),
                        new KeyValuePair<string, string>("CRM name", "crm_sell_point_name") }
                )
            );
            CustomReportStorageManager gsrmsm = new CustomReportStorageManager(
                new MsSqlCustomReportSaver(
                    new MsSqlDataTableStorageWorker(),
                    new MsSqlStorageInitializer(connectionString, "t_stg_gs_data", true, "dbo")
                )
            );
            gsrmsm.Save(gsrep);
            */
            // GA download and store in MS SQL

            GCustomReportInitializer reportInitializer = new GCustomReportInitializer(
                new GView("ga:157149180"),
                new DateTime(2019, 4, 1),
                new string [] {
                    "ga:sessions"
                },
                new string [] {
                    "ga:source",
                    "ga:medium",
                    "ga:campaign",
                    "ga:adContent",
                    "ga:keyword",
                    "ga:dimension3"
                }
            );
            GReportManager gaReportManager = new GReportManager(
                new GAnalyticsReportingV4CustomReportReciver(
                    new GConfig
                    {
                        CredentialUserAccountJsonPath = @"C:\a.shamshur\public_projects\integration\common_credentials\google\bi-dev-user-credentials.json"
                        //,CredentialServiceAccountJsonPath = @"C:\a.shamshur\public_projects\integration\common_credentials\google\bi-dev-001-06eaf0f926da.json"
                    }
                )
            );
            var re = gaReportManager.Get(reportInitializer);
            
            CustomReportStorageManager gsm = new CustomReportStorageManager(
                new MsSqlCustomReportSaver(
                    new MsSqlDataTableStorageWorker(),
                    new MsSqlStorageInitializer(connectionString, "t_stg_ga_data", true, "dbo")
                )
            );
            gsm.Save(re);
            /*
            // YANDEX
            
			var token = YCommonCredentialManager.Get(new RestCredentialInitializer(@"C:\a.shamshur\public_projects\integration\common_credentials\yandex\bi-dev-credentials.json"));
			YReportInitializer initializer = new YReportInitializer(
				new YCounter { Id = 52783963 },
                new DateTime(2019, 3, 14),
				new string [] {"ym:s:visits"},
                new string[] {"ym:s:UTMSource"}
            );
			YReportManager yrm = new YReportManager(new YRestReportReceiver(
                new YConfig
                {
                    TokensJsonPath = @"C:\a.shamshur\public_projects\integration\common_credentials\yandex\bi-dev-credentials.json",
                    ApiUrl = "https://api-metrika.yandex.net/"
                }
            ));
			var r = yrm.Get(initializer);
            CustomReportStorageManager ysm = new CustomReportStorageManager(
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
            ysm.Save(r);
            */

            //ADWORDS
            /*
            GADCustomReportManager p = new GADCustomReportManager(new ApiAdwrods201809CustomReportReceiver());
            var gadRep = p.Get(new GADCustomReportInitializer(
                new GADConfig {
                    CredentialsJsonPath = @"C:\a.shamshur\public_projects\integration\common_credentials\google\google-adwords-credentials_smartprice.json",
                    DeveloperToken = "QXcVkUmW93V6TcMiqnXlAA"
                },
                "250-186-1680",
                new string[] { "CampaignId", "Cost" },
                "CAMPAIGN_PERFORMANCE_REPORT",
                new DateTime(2019, 1, 1),
                new DateTime(2019, 5, 21)
            ));
            */

            //CALL-TOUCH
            /*
            CTConfig ctConfig = new CTConfig
            {
                TokensJsonPath = @"C:\a.shamshur\public_projects\integration\common_credentials\calltouch\credentials-28466.json"
            };
            CTCustomReportManager ctm = new CTCustomReportManager(new CTRestCallsReportReceiver(ctConfig));
            var ctr = ctm.Get(new CTCustomReportInitializer(
                "29196",
                new DateTime(2019, 4, 1),
                new DateTime(2019, 4, 1),
                new string[]
                {
                    "date",
                    "source",
                    "yaClientId"
                }
            ));
            CustomReportStorageManager ctsm = new CustomReportStorageManager(
                new MsSqlCustomReportSaver(
                    new MsSqlDataTableStorageWorker(),
                    new MsSqlStorageInitializer(
                        "Data Source=localhost;Initial Catalog=localdb;Integrated Security=True;MultipleActiveResultSets=True",
                        "t_stg_ct_data",
                        true,
                        "dbo"
                    )
                )
            );
            ctsm.Save(ctr);
            */

        }
    }
}

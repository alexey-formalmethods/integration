using bi_dev.integration.google.auth;
using Google.Api.Ads.AdWords.Lib;
using Google.Api.Ads.AdWords.Util.Reports;
using Google.Api.Ads.AdWords.Util.Reports.v201809;
using Google.Api.Ads.AdWords.v201809;
using Google.Api.Ads.Common.Util.Reports;
using System;
using System.IO;
using System.Linq;

namespace bi_dev.integration.google.adwords.reporting
{
    public class ApiAdwrods201809CustomReportReceiver: IGADCustomReportReceiver
    {
        public GADCustomReport Get(GADCustomReportInitializer initializer)
        {
            var cred = GCommonCredentialManager.Get(new GRestCredentialInitializer(initializer.Config.CredentialsJsonPath));
            AdWordsAppConfig config = new AdWordsAppConfig();
            config.DeveloperToken = initializer.Config.DeveloperToken;
            
            AdWordsUser user = new AdWordsUser(config);
            user.Config.OAuth2RefreshToken = cred.RefreshToken;
            user.Config.OAuth2AccessToken = cred.AccessToken;
            user.Config.OAuth2ClientId = cred.ClientId;
            user.Config.OAuth2ClientSecret = cred.ClientSecret;



            config.ClientCustomerId = initializer.Account.Id;
            // Create the required service.

            ReportQuery query = new ReportQueryBuilder()
                .Select(initializer.Columns.Select(x=>x.Name).ToArray())
                .From(initializer.Type.Name)
                .During(ReportDefinitionDateRangeType.LAST_7_DAYS)
                .Build();
            ReportUtilities utilities = new ReportUtilities(user, "v201809", query,
                    DownloadFormat.XML.ToString());
            
            using (ReportResponse response = utilities.GetResponse())
            {
                using (var sr = new StreamReader(response.Stream))
                {
                    var xmlResult = sr.ReadToEnd();
                }
            }

            throw new ArgumentException();
        }
    }
}

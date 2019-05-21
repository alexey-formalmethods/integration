using bi_dev.integration.google.auth;
using bi_dev.integration.reporting;
using Google.Api.Ads.AdWords.Lib;
using Google.Api.Ads.AdWords.Util.Reports;
using Google.Api.Ads.AdWords.Util.Reports.v201809;
using Google.Api.Ads.AdWords.v201809;
using Google.Api.Ads.Common.Util.Reports;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace bi_dev.integration.google.adwords.reporting
{
    public class ApiAdwrods201809CustomReportReceiver: IGADCustomReportReceiver
    {
        public GADCustomReport Get(GADCustomReportInitializer initializer)
        {
            GCommonCredentialsExtended cred = (GCommonCredentialsExtended)(new GCommonCredentialManager<GRestUserCredentialReceiver, GRestUserCredentialInitializer>().Get(new GRestUserCredentialInitializer(initializer.Config.CredentialsJsonPath, null)));
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
                .Select(initializer.Columns.Select(x=>x.Value.Name).ToArray())
                .From(initializer.Type.Name)
                .During(initializer.DateStart, initializer.DateEnd)
                .Build();
            ReportUtilities utilities = new ReportUtilities(user, "v201809", query,
                    DownloadFormat.XML.ToString());
            string xmlResult;
            using (ReportResponse response = utilities.GetResponse())
            {
                using (var sr = new StreamReader(response.Stream))
                {
                    xmlResult = sr.ReadToEnd();
                }
            }
            XmlSerializer serializer = new XmlSerializer(typeof(XML201809ReportResponse));
            XML201809ReportResponse xmlReport;
            using (TextReader tr = new StringReader(xmlResult))
            {
                xmlReport = (XML201809ReportResponse)serializer.Deserialize(tr);
            }
            GADCustomReport report = new GADCustomReport(initializer);
            report.Rows = xmlReport.Table.Row.Select(x => new CustomReportRow(
                    ((XmlNode[])x)
                    .Where(t=>initializer.Columns.ContainsKey(t.Name.ToLower()))
                    .Select(t=>new CustomReportCell(initializer.Columns[t.Name.ToLower()], t.Value)).ToArray()
                )
            ).ToArray();
            return report;
        }
    }
}

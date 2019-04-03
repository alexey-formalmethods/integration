using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace bi_dev.integration.calltouch.auth
{
    public class CTFileCredentialsInitializer: ICTCredentialInitializer
    {
        public string SiteId { get; }
        public string AccessToken { get; }
        public CTFileCredentialsInitializer(string siteId, string accessToken)
        {
            this.SiteId = siteId;
            this.AccessToken = accessToken;
        }
        public CTFileCredentialsInitializer(string credentialsJsonPath)
        {
            CredentialsFileModel response = JsonConvert.DeserializeObject<CredentialsFileModel>(File.ReadAllText(credentialsJsonPath));
            this.SiteId = response.SiteId;
            this.AccessToken = response.AccessToken;
        }

        public CTCommonCredentials Get()
        {
            return new CTCommonCredentials
            {
                AccessToken = this.AccessToken,
                SiteId = this.SiteId
            };
        }
    }
}

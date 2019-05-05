using bi_dev.integration.auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace bi_dev.integration.calltouch.auth
{
    public class CTFileCredentialsInitializer: ICTCredentialInitializer, IAuthInitializer
    {
        private CTCommonCredentials credentials = new CTCommonCredentials();
        public CTFileCredentialsInitializer(string credentialsJsonPath)
        {
            var response = JsonConvert.DeserializeObject<ICollection<CredentialsFileModel>>(File.ReadAllText(credentialsJsonPath));
            credentials.CredentialDictionary = response.Select(x=>new CTCommonCredentialsContent
            {
                AccessToken = x.AccessToken,
                Host = x.ApiHost,
                SiteId = x.SiteId
            }).ToDictionary(x => x.SiteId, x=>x);
            
        }
        public CTCommonCredentials Get()
        {
            return this.credentials;
        }
    }
}

using bi_dev.integration.auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.calltouch.auth
{
    public class CTCommonCredentials: ICredential
    {
        public Dictionary<string, CTCommonCredentialsContent> CredentialDictionary { get; set; }
    }

    public class CTCommonCredentialsContent
    {
        public string SiteId { get; set; }
        public string AccessToken { get; set; }
        public string Host { get; set; }
    }
}

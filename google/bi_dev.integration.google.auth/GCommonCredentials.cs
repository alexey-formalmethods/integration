using bi_dev.integration.auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Text;
using ICredential = bi_dev.integration.auth.ICredential;

namespace bi_dev.integration.google.auth
{
    public class GCommonCredentials: ICredential
    {
        public string AccessToken { get; set; }
        public GoogleCredential GoogleCredential { get; set; }
    }
    public class GCommonCredentialsExtended : GCommonCredentials
    {
        public string RefreshToken { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}

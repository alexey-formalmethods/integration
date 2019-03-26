using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.auth
{
    public class GCommonCredentials
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace bi_dev.integration.calltouch.auth
{
    public class CredentialsFileModel
    {
        [JsonProperty(PropertyName = "site_id")]
        public string SiteId { get; set; }

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }


    }
}

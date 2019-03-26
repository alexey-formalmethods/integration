using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.auth
{
    public class GCredentialsFileModel
    {
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }
    }
}

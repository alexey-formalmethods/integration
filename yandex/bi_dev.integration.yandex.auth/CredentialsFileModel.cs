using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.auth
{
    public class CredentialsFileModel
    {
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "client_id")]
		public string ClientId { get; set; }

		[JsonProperty(PropertyName = "Client_secret")]
		public string ClientSecret { get; set; }

		[JsonProperty(PropertyName = "callback_url")]
		public string CallbackUrl { get; set; }

		[JsonProperty(PropertyName = "refresh_token")]
		public string RefreshToken { get; set; }

	}
}

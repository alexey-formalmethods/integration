using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace bi_dev.integration.yandex.auth
{
    public class RestCredentialInitializer: ICredentialInitializer
	{
		string refreshToken;
		string clientId;
		string clientSecret;
		public RestCredentialInitializer(string refreshToken, string clientId, string clientSecret)
		{
			this.refreshToken = refreshToken;
			this.clientId = clientId;
			this.clientSecret = clientSecret;
		}
		public RestCredentialInitializer(string refreshTokenPath)
		{
			CredentialsFileModel response = JsonConvert.DeserializeObject<CredentialsFileModel>(File.ReadAllText(refreshTokenPath));
			this.refreshToken = response.RefreshToken;
			this.clientId = response.ClientId;
			this.clientSecret = response.ClientSecret;
		}

		public CommonCredentials Get()
		{
			WebClient wc = new WebClient();
			wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
			string body = $"grant_type=refresh_token&refresh_token={refreshToken}&client_id={clientId}&client_secret={clientSecret}";
			string result = wc.UploadString("https://oauth.yandex.ru/token", "POST", body);

			return new CommonCredentials
			{
				AccessToken = JsonConvert.DeserializeObject<RestTokenResponse>(result).AccessToken
			};
		}
	}
	class RestTokenResponse
	{
		[JsonProperty(PropertyName = "access_token")]
		public string AccessToken { get; set; }

		[JsonProperty(PropertyName = "token_type")]
		public string TokenType { get; set; }

		[JsonProperty(PropertyName = "expires_in")]
		public int ExpiresIn { get; set; }

		[JsonProperty(PropertyName = "refresh_token")]
		public string RefreshToken { get; set; }
	}
}

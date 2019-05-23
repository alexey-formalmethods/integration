using bi_dev.integration.auth;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace bi_dev.integration.yandex.auth
{
    public class YRestCredentialInitializer: ICredentialInitializer, IAuthInitializer
	{
		string refreshToken;
        public string RefreshToken { get => this.refreshToken; }

        string clientId;
        public string ClientId { get => this.clientId; }
		string clientSecret;
        public string ClientSecret { get => this.clientSecret; }
		public YRestCredentialInitializer(string refreshToken, string clientId, string clientSecret)
		{
			this.refreshToken = refreshToken;
			this.clientId = clientId;
			this.clientSecret = clientSecret;
		}
		public YRestCredentialInitializer(string refreshTokenPath)
		{
			CredentialsFileModel response = JsonConvert.DeserializeObject<CredentialsFileModel>(File.ReadAllText(refreshTokenPath));
			this.refreshToken = response.RefreshToken;
			this.clientId = response.ClientId;
			this.clientSecret = response.ClientSecret;
		}

		public YCommonCredentials Get()
		{
			WebClient wc = new WebClient();
			wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
			string body = $"grant_type=refresh_token&refresh_token={refreshToken}&client_id={clientId}&client_secret={clientSecret}";
			string result = wc.UploadString("https://oauth.yandex.ru/token", "POST", body);

			return new YCommonCredentials
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

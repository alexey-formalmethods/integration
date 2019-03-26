using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace bi_dev.integration.google.auth
{
    public class GRestCredentialInitializer : IGCredentialInitializer
    {
        string refreshToken;
        string clientId;
        string clientSecret;
        public GRestCredentialInitializer(string refreshToken, string clientId, string clientSecret)
        {
            this.refreshToken = refreshToken;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }
        public GRestCredentialInitializer(string refreshTokenPath)
        {
            GCredentialsFileModel response = JsonConvert.DeserializeObject<GCredentialsFileModel>(File.ReadAllText(refreshTokenPath));
            this.refreshToken = response.RefreshToken;
            this.clientId = response.ClientId;
            this.clientSecret = response.ClientSecret;
        }

        public GCommonCredentials Get()
        {
            WebClient wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
            string body = $"grant_type=refresh_token&refresh_token={refreshToken}&client_id={clientId}&client_secret={clientSecret}";
            string result = wc.UploadString("https://www.googleapis.com/oauth2/v4/token", "POST", body);

            return new GCommonCredentials
            {
                AccessToken = JsonConvert.DeserializeObject<RestTokenResponse>(result).AccessToken,
                ClientId = this.clientId,
                ClientSecret = this.clientSecret,
                RefreshToken = this.refreshToken
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

        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }
    }
}

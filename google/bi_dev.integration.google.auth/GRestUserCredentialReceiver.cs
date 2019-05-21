using bi_dev.integration.auth;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace bi_dev.integration.google.auth
{
    public class GRestUserCredentialReceiver : IGCredentialReceiver<GRestUserCredentialInitializer>
    {
        public GCommonCredentials Get(GRestUserCredentialInitializer initializer)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
            string body = $"grant_type=refresh_token&refresh_token={initializer.RefreshToken}&client_id={initializer.ClientId}&client_secret={initializer.ClientSecret}";
            string result = wc.UploadString("https://www.googleapis.com/oauth2/v4/token", "POST", body);
            var resultObj = JsonConvert.DeserializeObject<RestTokenResponse>(result);
            var googleCredentials = GoogleCredential.FromAccessToken(resultObj.AccessToken);
            if (initializer.Scopes != null && initializer.Scopes.Count > 0)
            {
                googleCredentials = googleCredentials.CreateScoped(initializer.Scopes);
            }
            return new GCommonCredentialsExtended
            {
                GoogleCredential = googleCredentials,
                AccessToken = resultObj.AccessToken,
                ClientId = initializer.ClientId,
                ClientSecret = initializer.ClientSecret,
                RefreshToken = initializer.RefreshToken
            };
           
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
}

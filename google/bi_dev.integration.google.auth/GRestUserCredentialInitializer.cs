using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace bi_dev.integration.google.auth
{
    public class GRestUserCredentialInitializer : IGAuthInitializer
    {
        public string RefreshToken { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
        public ICollection<string> Scopes { get; }
        public GRestUserCredentialInitializer(string refreshToken, string clientId, string clientSecret, ICollection<string> scopes)
        {
            this.RefreshToken = refreshToken;
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.Scopes = scopes;
        }
        public GRestUserCredentialInitializer(string refreshTokenPath, ICollection<string> scopes)
        {
            GCredentialsFileModel response = JsonConvert.DeserializeObject<GCredentialsFileModel>(File.ReadAllText(refreshTokenPath));
            this.RefreshToken = response.RefreshToken;
            this.ClientId = response.ClientId;
            this.ClientSecret = response.ClientSecret;
            this.Scopes = scopes;
        }
    }
    
}

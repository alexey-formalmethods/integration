using bi_dev.integration.auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace bi_dev.integration.yandex.auth
{
    public class YRestCredentialReceiver : ICredentialReceiver<YRestCredentialInitializer, YCommonCredentials>
    {
        public YCommonCredentials Get(YRestCredentialInitializer initializer)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
            string body = $"grant_type=refresh_token&refresh_token={initializer.RefreshToken}&client_id={initializer.ClientId}&client_secret={initializer.ClientSecret}";
            string result = wc.UploadString("https://oauth.yandex.ru/token", "POST", body);
            return new YCommonCredentials
            {
                AccessToken = JsonConvert.DeserializeObject<RestTokenResponse>(result).AccessToken
            };
        }
    }
}

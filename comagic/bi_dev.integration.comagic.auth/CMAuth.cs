using bi_dev.integration.auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace bi_dev.integration.comagic.auth
{
    public class CMCredential: ICredentialAccessToken
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
    }
    public class CMAuthInitializer : IAuthInitializerFile
    {
        public string FilePath { get; }
        public CMAuthInitializer (string filePath)
        {
            this.FilePath = filePath;
        }

    }
    public class CMAuthManager : IAuthManager<CMAuthInitializer, CMCredential>
    {
        public CMCredential Get(CMAuthInitializer initializer)
        {
            return JsonConvert.DeserializeObject<CMCredential>(File.ReadAllText(initializer.FilePath));
        }
    }
}

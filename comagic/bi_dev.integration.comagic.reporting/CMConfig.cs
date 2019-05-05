using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.comagic.reporting
{
    public abstract class CMConfig
    {
        public string ApiPath { get; }
        public string ApiVersion { get; }
        public string DateTimeInputFormat { get;}
        public CMConfig(string apiPath, string apiVersion, string dateTimeInputFormat)
        {
            this.ApiPath = apiPath;
            this.ApiVersion = apiVersion;
            this.DateTimeInputFormat = dateTimeInputFormat;
        }
    }
    public class CMConfigWithCredentailsPath : CMConfig
    {
        public string CredentialsFilePath { get; }
        public CMConfigWithCredentailsPath(string credentialsFilePath, string apiPath, string apiVersion, string dateTimeInputFormat) : base(apiPath, apiVersion, dateTimeInputFormat)
        {
            this.CredentialsFilePath = credentialsFilePath;
        }
    }
    public class CMConfigWithAccessToken : CMConfig
    {
        public string AccessToken { get; }
        public CMConfigWithAccessToken(string accessToken, string apiPath, string apiVersion, string dateTimeInputFormat) : base(apiPath, apiVersion, dateTimeInputFormat)
        {
            this.AccessToken = accessToken;
        }
    }
}

using bi_dev.integration.auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.auth
{
    public class YCommonCredentials: ICredential
    {
		public string AccessToken { get; set; }
    }
}

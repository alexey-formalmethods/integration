using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.auth
{
    public class YCommonCredentialManager
    {
		public static CommonCredentials Get(ICredentialInitializer initializer)
		{
			return initializer.Get();
		}
    }
}

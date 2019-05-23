using bi_dev.integration.auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.auth
{
    public class YCommonCredentialManager: AuthManager<YRestCredentialReceiver, YRestCredentialInitializer, YCommonCredentials>
    {
        /*
		public static YCommonCredentials Get(ICredentialInitializer initializer)
		{
			return initializer.Get();
		}
        */

    }
}

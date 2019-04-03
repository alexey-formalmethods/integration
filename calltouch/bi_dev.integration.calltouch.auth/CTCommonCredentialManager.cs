using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.calltouch.auth
{
    public class CTCommonCredentialManager
    {
        public static CTCommonCredentials Get(ICTCredentialInitializer initializer)
        {
            return initializer.Get();
        }
    }
}

using bi_dev.integration.auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.calltouch.auth
{
    public class CTCommonCredentialManager: IAuthManager<ICTCredentialInitializer, CTCommonCredentials>
    {
        public CTCommonCredentials Get(ICTCredentialInitializer initializer)
        {
            return initializer.Get();
        }
    }
}

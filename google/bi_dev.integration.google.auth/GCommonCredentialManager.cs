using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.auth
{
    public class GCommonCredentialManager
    {
        public static GCommonCredentials Get(IGCredentialInitializer initializer)
        {
            return initializer.Get();
        }
    }
}

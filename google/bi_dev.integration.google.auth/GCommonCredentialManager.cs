using bi_dev.integration.auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.auth
{
    public class GCommonCredentialManager<T, IT>: AuthManager<T, IT, GCommonCredentials> where T: IGCredentialReceiver<IT>, new() where IT: IGAuthInitializer
    {
        
    }
}

using bi_dev.integration.auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.auth
{
    public interface IGCredentialReceiver<T>: ICredentialReceiver<T, GCommonCredentials> where T: IGAuthInitializer
    {
    }

}

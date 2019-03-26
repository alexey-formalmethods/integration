using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.auth
{
    public interface IGCredentialInitializer
    {
        GCommonCredentials Get();
    }
}

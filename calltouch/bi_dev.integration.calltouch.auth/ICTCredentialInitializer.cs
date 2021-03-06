﻿using bi_dev.integration.auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.calltouch.auth
{
    public interface ICTCredentialInitializer: IAuthInitializer
    {
        CTCommonCredentials Get();
    }
}

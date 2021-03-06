﻿using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.auth
{
    public interface ICredentialReceiver<T, CT> where T : IAuthInitializer where CT : ICredential
    {
        CT Get(T initializer);
    }
}

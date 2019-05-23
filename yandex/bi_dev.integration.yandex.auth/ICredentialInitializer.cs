using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.auth
{
    public interface ICredentialInitializer
    {
		YCommonCredentials Get();
    }
}

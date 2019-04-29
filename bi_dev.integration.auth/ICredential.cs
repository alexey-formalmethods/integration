using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.auth
{
    public interface ICredential
    {
    }
    public interface ICredentialAccessToken: ICredential
    {
        string AccessToken { get; set; }
    }
}

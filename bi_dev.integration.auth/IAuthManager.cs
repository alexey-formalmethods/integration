using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.auth
{
    public interface IAuthManager<T, CT> where T : IAuthInitializer where CT : ICredential
    {
        CT Get(T initializer);
    }
    public abstract class AuthManager<T, IT, CT> where T: ICredentialReceiver<IT, CT>, new() where IT: IAuthInitializer where CT: ICredential
    {
        public CT Get(IT initializer)
        {
            return new T().Get(initializer);
        }
    }
}

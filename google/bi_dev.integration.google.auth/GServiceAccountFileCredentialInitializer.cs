using bi_dev.integration.auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.auth
{
    public class GServiceAccountFileCredentialInitializer: IGAuthInitializer
    {
        public string CredentialServiceAccountJsonPath { get; }
        public ICollection<string> ScopeCollection { get; }
        public GServiceAccountFileCredentialInitializer(string credentialServiceAccountJsonPath)
        {
            this.CredentialServiceAccountJsonPath = credentialServiceAccountJsonPath;
        }
        public GServiceAccountFileCredentialInitializer(string credentialServiceAccountJsonPath, ICollection<string> scopeCollection)
        {
            this.CredentialServiceAccountJsonPath = credentialServiceAccountJsonPath;
            this.ScopeCollection = scopeCollection;
        }
    }
}

using Google.Apis.Auth.OAuth2;
using System;
using System.Collections;
using System.Collections.Generic;

namespace bi_dev.integration.google.auth
{
	public class GServiceAccountCredentialManager: IGCredentialInitializer
    {
        private string credentialServiceAccountJsonPath;
        private ICollection<string> scopeCollection;
        public GoogleCredential ScopedCredential { get; }
        public GServiceAccountCredentialManager(string credentialServiceAccountJsonPath, ICollection<string> scopeCollection = null)
        {
            this.credentialServiceAccountJsonPath = credentialServiceAccountJsonPath;
            this.scopeCollection = scopeCollection;
            this.ScopedCredential = GetCredentials(this.credentialServiceAccountJsonPath, this.scopeCollection);
        }
        public static GoogleCredential GetCredentials(string credentialServiceAccountJsonPath, ICollection<string> scopeCollection)
		{
			// If you don't specify credentials when constructing the client, the
			// client library will look for credentials in the environment.
            
			var credential = GoogleCredential.FromFile(credentialServiceAccountJsonPath);
            if (scopeCollection != null)
            {
                return credential.CreateScoped(scopeCollection);
            }
            else
            {
                return credential;
            }
		}

        public GCommonCredentials Get()
        {
            return new GCommonCredentials { AccessToken = this.ScopedCredential.UnderlyingCredential.GetAccessTokenForRequestAsync().Result };
        }
    }
}

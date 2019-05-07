using bi_dev.integration.auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections;
using System.Collections.Generic;

namespace bi_dev.integration.google.auth
{
	public class GServiceAccountFileCredentialReceiver : IGCredentialReceiver<GServiceAccountFileCredentialInitializer>
    {
        /*
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
        */
        public GCommonCredentials Get(GServiceAccountFileCredentialInitializer initializer)
        {
            var credential = GoogleCredential.FromFile(initializer.CredentialServiceAccountJsonPath);
            if (initializer.ScopeCollection != null && initializer.ScopeCollection.Count > 0)
            {
                credential = credential.CreateScoped(initializer.ScopeCollection);
            }
            return new GCommonCredentials
            {
                GoogleCredential = credential,
                AccessToken = credential.UnderlyingCredential.GetAccessTokenForRequestAsync().Result
            };
        }
    }
}

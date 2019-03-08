using Google.Apis.Auth.OAuth2;
using System;
using System.Collections;
using System.Collections.Generic;

namespace bi_dev.integration.google.auth
{
	
	public class CredentialManager
    {
		public static GoogleCredential GetCredentials(string credentialServiceAccountJsonPath, ICollection<string> scopeCollection)
		{
			// If you don't specify credentials when constructing the client, the
			// client library will look for credentials in the environment.
			var credential = GoogleCredential.FromFile(credentialServiceAccountJsonPath);
			var scopedCredential = credential.CreateScoped(scopeCollection);
			return scopedCredential;
		}

	}
}

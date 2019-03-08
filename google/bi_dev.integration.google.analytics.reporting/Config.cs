using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class Config
    {
		public string CredentialServiceAccountJsonPath { get; set; }
		private static Config currentConfig;
		public static Config CurrentConfig
		{
			get
			{
				if (currentConfig == null) currentConfig = new Config();
				return currentConfig;
			}
			set
			{
				currentConfig = value;
			}
		}

	}
}

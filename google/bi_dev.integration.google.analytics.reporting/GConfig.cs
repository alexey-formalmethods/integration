using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GConfig
    {
		public string CredentialServiceAccountJsonPath { get; set; }
		private static GConfig currentConfig;
		public static GConfig CurrentConfig
		{
			get
			{
				if (currentConfig == null) currentConfig = new GConfig();
				return currentConfig;
			}
			set
			{
				currentConfig = value;
			}
		}

	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public static class Constants
    {
		public static readonly string[] Scopes = new string[] { "https://www.googleapis.com/auth/analytics.readonly" };
		public const string DateParamFormat = "yyyy-MM-dd";
}
}

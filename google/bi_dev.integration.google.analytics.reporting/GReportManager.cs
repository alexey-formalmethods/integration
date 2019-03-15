using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GReportManager
    {
		GBaseReportInitializer initializer;
		public GReportManager(GBaseReportInitializer initializer)
		{
			this.initializer = initializer;
		}
		public GCustomReport Get()
		{
			return this.initializer.Get();
		}
	}
}

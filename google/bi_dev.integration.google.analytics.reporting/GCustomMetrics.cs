using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GCustomMetric: CustomReportColumn, IGCustomParameter
	{
		public GCustomMetric(string name): base(typeof(string), name)
		{
			
		}
	}
	public class GCustomMetricValued: CustomReportCell
	{
		public GCustomMetricValued(string name, string value): base(new GCustomMetric(name), value)
		{
		}
	}
}

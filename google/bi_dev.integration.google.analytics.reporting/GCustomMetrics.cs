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
        public GCustomMetric(string name, string alterName) : base(typeof(string), name, alterName)
        {

        }
    }
	public class GCustomMetricValued: CustomReportCell
	{
		public GCustomMetricValued(GCustomMetric metric, string value): base(metric, value)
		{
		}
	}
}

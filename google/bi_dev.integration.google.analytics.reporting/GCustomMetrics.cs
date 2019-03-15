using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GCustomMetric: IGCustomParameter
	{
		public string Name { get; set; }
		public GCustomMetric(string name)
		{
			this.Name = name;
		}
	}
	public class GCustomMetricValued: GCustomMetric, IGCustomParameterValued
	{
		public string Value { get; set; }

		public GCustomMetricValued(string name, string value): base(name)
		{
			this.Value = value;
		}
	}
}

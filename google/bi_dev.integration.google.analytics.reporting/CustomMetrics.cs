using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class CustomMetric: ICustomParameter
	{
		public string Name { get; set; }
		public CustomMetric(string name)
		{
			this.Name = name;
		}
	}
	public class CustomMetricValued: CustomMetric, ICustomParameterValued
	{
		public string Value { get; set; }

		public CustomMetricValued(string name, string value): base(name)
		{
			this.Value = value;
		}
	}
}

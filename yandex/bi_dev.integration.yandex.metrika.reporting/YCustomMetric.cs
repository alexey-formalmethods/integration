using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public class YCustomMetric: IYCustomParameter
	{
		public string Name { get; set; }
		public YCustomMetric(string name)
		{
			this.Name = name;
		}
	}
	public class YCustomMetricValued : YCustomMetric, IYCustomParameterValued
	{
		public string Value { get; set; }
		public YCustomMetricValued(string name, string value) : base(name)
		{
			this.Value = value;
		}
	}
}

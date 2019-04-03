using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public class YCustomMetric: CustomReportColumn
	{
		public YCustomMetric(string name): base(typeof(string), name) { }
    }
	public class YCustomMetricValued : CustomReportCell
	{
		public YCustomMetricValued(string name, string value) : base(new YCustomMetric(name), value)
		{
		}
	}
}

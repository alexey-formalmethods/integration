using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public class YCustomDimension: CustomReportColumn
	{
		public YCustomDimension(string name): base(typeof(string), name)
		{
		}
	}
	public class YCustomDimensionValued: CustomReportCell
	{
		public YCustomDimensionValued (string name, string value): base(new YCustomDimension(name), value)
		{
		}
	}
}

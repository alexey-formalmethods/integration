using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GCustomDimension: CustomReportColumn
    {
		public GCustomDimension(string name): base(typeof(string), name)
		{
		}
	}
	public class GCustomDimensionValued: CustomReportCell
	{
		public GCustomDimensionValued (string name, string value): base (new GCustomDimension(name), value)
		{
		}
	}
}

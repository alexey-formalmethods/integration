using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GCustomDimension: IGCustomParameter
	{
		public string Name { get; set; }
		public GCustomDimension() { }
		public GCustomDimension(string name)
		{
			this.Name = name;
		}
	}
	public class GCustomDimensionValued: GCustomDimension, IGCustomParameterValued
	{
		public string Value { get; set; }
		public GCustomDimensionValued (string name, string value)
		{
			base.Name = name;
			this.Value = value;
		}
	}
}

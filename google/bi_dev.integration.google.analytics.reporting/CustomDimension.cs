using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class CustomDimension: ICustomParameter
	{
		public string Name { get; set; }
		public CustomDimension() { }
		public CustomDimension(string name)
		{
			this.Name = name;
		}
	}
	public class CustomDimensionValued: CustomDimension, ICustomParameterValued
	{
		public string Value { get; set; }
		public CustomDimensionValued (string name, string value)
		{
			base.Name = name;
			this.Value = value;
		}
	}
}

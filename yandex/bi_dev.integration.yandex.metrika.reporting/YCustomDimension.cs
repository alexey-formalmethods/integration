using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public class YCustomDimension: IYCustomParameter
	{
		public string Name { get; set; }
		public YCustomDimension() { }
		public YCustomDimension(string name)
		{
			this.Name = name;
		}
	}
	public class YCustomDimensionValued: YCustomDimension, IYCustomParameterValued
	{
		public string Value { get; set; }
		public YCustomDimensionValued (string name, string value): base(name)
		{
			this.Value = value;
		}
	}
}

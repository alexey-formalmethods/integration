using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public interface ICustomParameter
    {
		string Name { get; set; }
    }
	public interface ICustomParameterValued: ICustomParameter
	{
		string Value { get; set; }
		
	}
}

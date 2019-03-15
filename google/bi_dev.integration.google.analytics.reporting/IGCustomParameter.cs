using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public interface IGCustomParameter
    {
		string Name { get; set; }
    }
	public interface IGCustomParameterValued: IGCustomParameter
	{
		string Value { get; set; }
		
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
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

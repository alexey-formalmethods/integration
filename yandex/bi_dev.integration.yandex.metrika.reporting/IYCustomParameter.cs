using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public interface IYCustomParameter
    {
		string Name { get; set; }
    }
	public interface IYCustomParameterValued: IYCustomParameter
	{
		string Value { get; set; }
		
	}
}

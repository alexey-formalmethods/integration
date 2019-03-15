using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
	public class YReportManager
	{
		YBaseReportInitializer initializer;
		public YReportManager(YBaseReportInitializer initializer)
		{
			this.initializer = initializer;
		}
		public YCustomReport Get()
		{
			return this.initializer.Get();
		}
	}
}

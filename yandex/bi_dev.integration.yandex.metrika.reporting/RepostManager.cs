using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
	public class ReportManager
	{
		BaseReportInitializer initializer;
		public ReportManager(BaseReportInitializer initializer)
		{
			this.initializer = initializer;
		}
		public CustomReport Get()
		{
			return this.initializer.Get();
		}
	}
}

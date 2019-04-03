using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
	public class YReportManager: CustomReportManager<YCustomReport, YReportInitializer, YRestReportReceiver>
	{
		public YReportManager(YRestReportReceiver receiver) : base(receiver)
		{
		}
	}
}

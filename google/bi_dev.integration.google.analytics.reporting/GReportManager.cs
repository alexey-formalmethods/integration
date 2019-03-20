using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GReportManager
    {
        IGCustomReportReceiver receiver;
        public GReportManager(IGCustomReportReceiver receiver)
		{
            this.receiver = receiver;
        }
		public GCustomReport Get(GCustomReportInitializer initializer)
		{
			return this.receiver.Get(initializer);
		}
	}
}

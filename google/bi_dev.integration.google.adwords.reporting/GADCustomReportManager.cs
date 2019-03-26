using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public class GADCustomReportManager
    {
        IGADCustomReportReceiver receiver;
        public GADCustomReportManager(IGADCustomReportReceiver receiver)
        {
            this.receiver = receiver;
        }
        public GADCustomReport Get(GADCustomReportInitializer initializer)
        {
            return this.receiver.Get(initializer);
        }
    }
}

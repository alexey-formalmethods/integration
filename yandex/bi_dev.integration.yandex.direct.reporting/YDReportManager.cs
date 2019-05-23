using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.direct.reporting
{
    public class YDReportManager : CustomReportManager<YDCustomReport, YDCustomReportInitializer, YDRestApi5CustomReportReceiver>
    {
        public YDReportManager(YDRestApi5CustomReportReceiver receiver) : base(receiver)
        {
        }
    }
}

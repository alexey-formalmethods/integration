using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting.storage
{
    public interface IReportSaver
    {
		void Save(ReportInitializer reportInitializer);
    }
}

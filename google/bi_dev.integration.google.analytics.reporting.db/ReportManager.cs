using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting.storage
{
    public class ReportManager
    {
		private ReportInitializer reportInitializer;
		private IReportSaver reportWorker;
		public ReportManager (ReportInitializer reportInitializer, IReportSaver reportWorker)
		{
			this.reportInitializer = reportInitializer;
			this.reportWorker = reportWorker;
		}
		public void Save()
		{
			reportWorker.Save(reportInitializer);
		}
	}
}

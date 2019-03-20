using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting.storage
{
    public class ReportStorageManager
    {
		private IReportSaver reportSaver;
		public ReportStorageManager(IReportSaver reportSaver)
		{
			this.reportSaver = reportSaver;
		}
		public void Save(GCustomReport report)
		{
			reportSaver.Save(report);
		}
	}
}

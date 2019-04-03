using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.reporting.storage
{
    public class CustomReportStorageManager
    {
		private ICustomReportSaver reportSaver;
		public CustomReportStorageManager(ICustomReportSaver reportSaver)
		{
			this.reportSaver = reportSaver;
		}
		public void Save(ICustomReport report)
		{
			reportSaver.Save(report);
		}
	}
}

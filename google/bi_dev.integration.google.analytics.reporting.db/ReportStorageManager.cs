﻿using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting.storage
{
    public class ReportStorageManager
    {
		private CustomReport report;
		private IReportSaver reportSaver;
		public ReportStorageManager(CustomReport report, IReportSaver reportSaver)
		{
			this.report = report;
			this.reportSaver = reportSaver;
		}
		public void Save()
		{
			reportSaver.Save(report);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting.storage
{
    public static class Extensions
    {
		public static void SaveToMsSql(this CustomReport report, MsSqlReportSaver msSqlReportSaver)
		{
			msSqlReportSaver.Save(report);
		}
    }
}

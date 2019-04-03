using bi_dev.integration.utils;
using bi_dev.integration.utils.storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.reporting.storage
{
    public interface ICustomReportSaver
    {
        void Save(ICustomReport report);
    }
}

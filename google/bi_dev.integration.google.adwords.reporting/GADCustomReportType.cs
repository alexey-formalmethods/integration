using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public class GADCustomReportType
    {
        public string Name { get;}
        public GADCustomReportType(string name)
        {
            this.Name = name;
        }
        public GADCustomReportType(GADReportTypeEnum type)
        {
            this.Name = type.ToString();
        }
        public GADReportTypeEnum Value { get { throw new NotImplementedException(" lol kek 4eburek"); } }
    }
    public enum GADReportTypeEnum
    {
        CAMPAIGN_PERFORMANCE_REPORT = 100
    }
}

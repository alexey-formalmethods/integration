using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.reporting.dimensional
{
    public class CustomMetric: ICustomReportParameter
    {
        public string Name { get; set; }
    }
    public class CustomMetric<T>: CustomMetric, ICustomReportParameter<T>, ICustomReportParameter
    {
        public T Value { get; set; }
        public string StringValue
        {
            get
            {
                return this.Value.ToString();
            }
        }
    }
}

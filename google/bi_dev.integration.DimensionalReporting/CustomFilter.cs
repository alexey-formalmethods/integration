using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.reporting.dimensional
{
    
    public class CustomFilter<T>: ICustomReportParameter<T>, ICustomReportParameterString
    {
        public string Name { get; set; }
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

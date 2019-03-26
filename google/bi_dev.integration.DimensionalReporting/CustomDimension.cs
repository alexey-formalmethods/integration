using System;

namespace bi_dev.integration.reporting.dimensional
{
    public class CustomDimension: ICustomReportParameter
    {
        public string Name { get; set; }
    }
    public class CustomDimension<T>: CustomDimension, ICustomReportParameter<T>, ICustomReportParameterString
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

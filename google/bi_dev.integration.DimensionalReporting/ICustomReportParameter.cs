using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.reporting.dimensional
{
    public interface ICustomReportParameter
    {
        string Name { get; set; }
    }
    public interface ICustomReportParameter<T>: ICustomReportParameter
    {
        T Value { get; set; }
    }
    public interface ICustomReportParameterString: ICustomReportParameter
    {
        string StringValue { get; }
    }
}

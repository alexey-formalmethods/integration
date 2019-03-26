using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public interface IGADCustomParameter
    {
        string Name { get; set; }
    }
    public interface IGADCustomParameterValued : IGADCustomParameter
    {
        string Value { get; set; }

    }
}

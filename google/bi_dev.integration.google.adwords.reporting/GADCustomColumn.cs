using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public class GADCustomColumn : CustomReportColumn, IGADCustomParameter
    {
        
        public GADCustomColumn(string name): base(typeof(string), name)
        {
            
        }
        
    }
    public class GADCustomColumnValued : GADCustomColumn, IGADCustomParameterValued
    {
        public GADCustomColumnValued(string name): base(name)
        {

        }
        public string Value { get; set; }
    }
}

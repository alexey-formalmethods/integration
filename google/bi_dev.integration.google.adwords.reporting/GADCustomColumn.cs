using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public class GADCustomColumn : IGADCustomParameter
    {
        public string Name { get; set; }
        public GADCustomColumn(string name)
        {
            this.Name = name;
        }
        public GADCustomColumn()
        {
        }
    }
    public class GADCustomColumnValued : GADCustomColumn, IGADCustomParameterValued
    {
        public string Value { get; set; }
    }
}

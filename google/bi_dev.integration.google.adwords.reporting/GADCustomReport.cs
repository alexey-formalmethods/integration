using bi_dev.integration.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace bi_dev.integration.google.adwords.reporting
{
    public class GADCustomReport: IDataTableTransformable
    {
        protected GADCustomReportInitializer initializer;
        public ICollection<CustomReportRow> Rows { get; set; }

        public GADCustomReport(GADCustomReportInitializer initializer)
        {
            this.initializer = initializer;
        }

        public DataTable ToDataTable()
        {
            DataTable dt = new DataTable();
            throw new NotImplementedException("eshe ne gotovo");
            
        }
    }
    public class CustomReportRow
    {
        public ICollection<IGADCustomParameterValued> Cells { get; set; }
        public CustomReportRow(ICollection<IGADCustomParameterValued> cells)
        {
            this.Cells = cells;
        }
    }
}

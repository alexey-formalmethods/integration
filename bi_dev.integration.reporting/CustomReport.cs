using bi_dev.integration.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bi_dev.integration.reporting
{
    public interface ICustomReport: IDataTableTransformable
    {
        ICollection<CustomReportRow> Rows { get; set; }
    }
    public abstract class CustomReport<T> : IDataTableTransformable, ICustomReport where T: ICustomReportInitializer
    {
        protected T initializer;
        public T Initializer { get { return this.initializer; } }

        public ICollection<CustomReportRow> Rows { get; set; }

        public CustomReport(T initializer)
        {
            this.initializer = initializer;
            this.Rows = new List<CustomReportRow>();
        }

        public virtual DataTable ToDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(this.Initializer.Columns.Select(x => new DataColumn(x.Value.AlterName)).ToArray());
            
            foreach(var row in this.Rows)
            {
                var dtRow = dt.NewRow();
                foreach(var cell in row.Cells)
                {
                    if (dtRow.Table.Columns.Contains(cell.Column.AlterName))
                    {
                        dtRow[cell.Column.AlterName] = cell.Value;
                    }
                }
                dt.Rows.Add(dtRow);
            }
            return dt;
        }

    }
}

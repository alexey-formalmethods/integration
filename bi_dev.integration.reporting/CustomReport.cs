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
        }

        public virtual DataTable ToDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(this.Initializer.Columns.Select(x => new DataColumn(x.Value.AlterName)).ToArray());

            foreach(var row in this.Rows)
            {
                dt.Rows.Add(
                    row.Cells.Where(
                        x => this.Initializer.Columns.ContainsKey(x.Column.AlterName)
                    ).Select(x => x.Value).ToArray());
            }
            return dt;
        }

    }
}

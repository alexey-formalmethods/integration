using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.reporting
{
    
    public abstract class CustomReportColumn
    {
        public string Name { get; set; }
        private string alterName;
        public string AlterName { get { return (string.IsNullOrEmpty(this.alterName)?this.Name: this.alterName); } }
        public Type ValueType { get; set; }
        public CustomReportColumn(Type valueType, string name)
        {
            this.ValueType = valueType;
            this.Name = name;
            this.alterName = name;
        }
        public CustomReportColumn(Type valueType, string name, string alterName)
        {
            this.ValueType = valueType;
            this.Name = name;
            this.alterName = alterName;
        }
    }
    public class CustomReportColumn<T>: CustomReportColumn
    {
        public CustomReportColumn(string name): base(typeof(T), name)
        {

        }
        public CustomReportColumn(string name, string alterName) : base(typeof(T), name, alterName)
        {

        }
    }
    public class CustomReportRow
    {
        public ICollection<CustomReportCell> Cells { get; set; }
        public CustomReportRow(ICollection<CustomReportCell> cells)
        {
            this.Cells = cells;
        }
        public CustomReportRow() { }
    }
    
    public class CustomReportCell<T>
    {
        public CustomReportColumn Column { get; set; }
        public T Value { get; set; }
        protected Type valueType;
        public Type ValueType { get { return this.valueType; } }
        public CustomReportCell(CustomReportColumn column, T value)
        {
            this.Column = column;
            this.Value = value;
            this.valueType = typeof(T);
        }
    }
    public class CustomReportCell: CustomReportCell<string>
    {
        public CustomReportCell(CustomReportColumn column, string value): base(column, value)
        {
        }
    }
    public class CustomReportCellObject : CustomReportCell<object>
    {
        public CustomReportCellObject(CustomReportColumn column, string value, Type valueType) : base(column, value)
        {
            base.valueType = valueType;
        }
    }
}

using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public class YReportInitializer: ICustomReportInitializer
    {
		protected YConfig config;
        public YConfig Config { get { return this.config; } }
		public ICollection<YCustomDimension> Dimensions { get; }
		public ICollection<YCustomMetric> Metrics { get; }
		public DateTime DateStart { get; }
		public DateTime DateEnd { get; }
		public YCounter Counter { get; }
		public IDictionary<string, CustomReportColumn> Columns
		{
			get
			{
				Dictionary<string, CustomReportColumn> col = new Dictionary<string, CustomReportColumn>();
                foreach(var dim in this.Dimensions)
                {
                    if (!col.ContainsKey(dim.AlterName))
                    {
                        col.Add(dim.AlterName, dim);
                    }
                }
                foreach (var metr in this.Metrics)
                {
                    if (!col.ContainsKey(metr.AlterName))
                    {
                        col.Add(metr.AlterName, metr);
                    }
                }
				return col;
			}
		}
		public YReportInitializer(YConfig config, YCounter counter, ICollection<YCustomDimension> dimensions, ICollection<YCustomMetric> metrics, DateTime dateStart)
		{
			this.config = config;
			this.Counter = counter;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateStart;
		}
		public YReportInitializer(YConfig config, YCounter counter, ICollection<YCustomDimension> dimensions, ICollection<YCustomMetric> metrics, DateTime dateStart, DateTime dateEnd)
		{
			this.config = config;
			this.Counter = counter;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateEnd;
		}
	}
}

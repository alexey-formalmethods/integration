using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public class YReportInitializer: ICustomReportInitializer
    {
		
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
		public YReportInitializer(YCounter counter, DateTime dateStart, ICollection<YCustomMetric> metrics, ICollection<YCustomDimension> dimensions)
		{
			this.Counter = counter;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateStart;
		}
		public YReportInitializer(YCounter counter, DateTime dateStart, DateTime dateEnd, ICollection<YCustomMetric> metrics, ICollection<YCustomDimension> dimensions)
		{
			this.Counter = counter;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateEnd;
		}
        public YReportInitializer(YCounter counter, DateTime dateStart, ICollection<string> metrics, ICollection<string> dimensions)
        {
            this.Counter = counter;
            this.Dimensions = dimensions.Select(x=>new YCustomDimension(x)).ToArray();
            this.Metrics = metrics.Select(x => new YCustomMetric(x)).ToArray();
            this.DateStart = dateStart;
            this.DateEnd = dateStart;
        }
        public YReportInitializer(YCounter counter, DateTime dateStart, DateTime dateEnd, ICollection<string> metrics, ICollection<string> dimensions)
        {
            this.Counter = counter;
            this.Dimensions = dimensions.Select(x => new YCustomDimension(x)).ToArray();
            this.Metrics = metrics.Select(x => new YCustomMetric(x)).ToArray();
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
        }
        public YReportInitializer(YCounter counter, DateTime dateStart, ICollection<string> metrics)
        {
            this.Counter = counter;
            this.Dimensions = new YCustomDimension[0];
            this.Metrics = metrics.Select(x => new YCustomMetric(x)).ToArray();
            this.DateStart = dateStart;
            this.DateEnd = dateStart;
        }
        public YReportInitializer(YCounter counter, DateTime dateStart, DateTime dateEnd, ICollection<string> metrics)
        {
            this.Counter = counter;
            this.Dimensions = new YCustomDimension[0];
            this.Metrics = metrics.Select(x => new YCustomMetric(x)).ToArray();
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
        }


    }
}

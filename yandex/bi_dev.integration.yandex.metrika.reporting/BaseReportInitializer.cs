using System;
using System.Collections.Generic;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public abstract class BaseReportInitializer
    {
		protected Config config;
		public ICollection<CustomDimension> Dimensions { get; }
		public ICollection<CustomMetric> Metrics { get; }
		public DateTime DateStart { get; }
		public DateTime DateEnd { get; }
		public Counter Counter { get; }
		public ICollection<ICustomParameter> DimensionMetricsParams
		{
			get
			{
				List<ICustomParameter> prm = new List<ICustomParameter>();
				prm.AddRange(this.Dimensions);
				prm.AddRange(this.Metrics);
				return prm;
			}
		}

		private CustomReport report;
		public CustomReport Report
		{
			get
			{
				if (this.report == null)
				{
					this.report = Get();
				}
				return this.report;
			}
		}
		public BaseReportInitializer(Config config, Counter counter, ICollection<CustomDimension> dimensions, ICollection<CustomMetric> metrics, DateTime dateStart)
		{
			this.config = config;
			this.Counter = counter;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateStart;
		}
		public BaseReportInitializer(Config config, Counter counter, ICollection<CustomDimension> dimensions, ICollection<CustomMetric> metrics, DateTime dateStart, DateTime dateEnd)
		{
			this.config = config;
			this.Counter = counter;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateEnd;
		}

		public abstract CustomReport Get();
	}
}

using System;
using System.Collections.Generic;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public abstract class YBaseReportInitializer
    {
		protected YConfig config;
		public ICollection<YCustomDimension> Dimensions { get; }
		public ICollection<YCustomMetric> Metrics { get; }
		public DateTime DateStart { get; }
		public DateTime DateEnd { get; }
		public YCounter Counter { get; }
		public ICollection<IYCustomParameter> DimensionMetricsParams
		{
			get
			{
				List<IYCustomParameter> prm = new List<IYCustomParameter>();
				prm.AddRange(this.Dimensions);
				prm.AddRange(this.Metrics);
				return prm;
			}
		}

		private YCustomReport report;
		public YCustomReport Report
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
		public YBaseReportInitializer(YConfig config, YCounter counter, ICollection<YCustomDimension> dimensions, ICollection<YCustomMetric> metrics, DateTime dateStart)
		{
			this.config = config;
			this.Counter = counter;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateStart;
		}
		public YBaseReportInitializer(YConfig config, YCounter counter, ICollection<YCustomDimension> dimensions, ICollection<YCustomMetric> metrics, DateTime dateStart, DateTime dateEnd)
		{
			this.config = config;
			this.Counter = counter;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateEnd;
		}

		public abstract YCustomReport Get();
	}
}

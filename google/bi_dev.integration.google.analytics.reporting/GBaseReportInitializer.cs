using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{

	public abstract class GBaseReportInitializer
    {
		protected GConfig config;

		public ICollection<GCustomDimension> Dimensions { get; }
		public ICollection<GCustomMetric> Metrics { get; }
		public DateTime DateStart { get; }
		public DateTime DateEnd { get;}
		public GView View { get; }

		public ICollection<IGCustomParameter> DimensionMetricsParams
		{
			get
			{
				List<IGCustomParameter> prm = new List<IGCustomParameter>();
				prm.AddRange(this.Dimensions);
				prm.AddRange(this.Metrics);
				return prm;
			}
		}

		private GCustomReport report;
		public GCustomReport Report
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
		public GBaseReportInitializer(GConfig config, GView view, ICollection<GCustomDimension> dimensions, ICollection<GCustomMetric> metrics, DateTime dateStart)
		{
			this.config = config;
			this.View = view;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateStart;
		}
		public GBaseReportInitializer(GConfig config, GView view, ICollection<GCustomDimension> dimensions, ICollection<GCustomMetric> metrics, DateTime dateStart, DateTime dateEnd)
		{
			this.config = config;
			this.View = view;
			this.Dimensions = dimensions;
			this.Metrics = metrics;
			this.DateStart = dateStart;
			this.DateEnd = dateEnd;
		}

		public abstract GCustomReport Get();

	}
}

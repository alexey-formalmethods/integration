using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GCustomReportInitializer
    {
        public GConfig Config { get; }

        public ICollection<GCustomDimension> Dimensions { get; }
        public ICollection<GCustomMetric> Metrics { get; }
        public DateTime DateStart { get; }
        public DateTime DateEnd { get; }
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
        public GCustomReportInitializer(GConfig config, GView view, ICollection<GCustomDimension> dimensions, ICollection<GCustomMetric> metrics, DateTime dateStart)
        {
            this.Config = config;
            this.View = view;
            this.Dimensions = dimensions;
            this.Metrics = metrics;
            this.DateStart = dateStart;
            this.DateEnd = dateStart;
        }
        public GCustomReportInitializer(GConfig config, GView view, ICollection<GCustomDimension> dimensions, ICollection<GCustomMetric> metrics, DateTime dateStart, DateTime dateEnd)
        {
            this.Config = config;
            this.View = view;
            this.Dimensions = dimensions;
            this.Metrics = metrics;
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
        }
    }
}

using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GCustomReportInitializer: ICustomReportInitializer
    {
        public GConfig Config { get; }

        public ICollection<GCustomDimension> Dimensions { get; }
        public ICollection<GCustomMetric> Metrics { get; }
        public DateTime DateStart { get; }
        public DateTime DateEnd { get; }
        public GView View { get; }

        public IDictionary<string, CustomReportColumn> Columns
        {
            get
            {
                Dictionary<string, CustomReportColumn> columns = new Dictionary<string, CustomReportColumn>();
                foreach(var dim in this.Dimensions)
                {
                    if (!columns.ContainsKey(dim.AlterName))
                    {
                        columns.Add(dim.AlterName, dim);
                    }
                }
                foreach (var metr in this.Metrics)
                {
                    if (!columns.ContainsKey(metr.AlterName))
                    {
                        columns.Add(metr.AlterName, metr);
                    }
                }
                return columns;
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

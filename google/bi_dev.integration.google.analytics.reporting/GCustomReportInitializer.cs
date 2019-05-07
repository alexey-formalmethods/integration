using bi_dev.integration.reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bi_dev.integration.google.analytics.reporting
{
    public class GCustomReportInitializer: ICustomReportInitializer
    {
        //public GConfig Config { get; }

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
                // columns.Add("date_from", new CustomReportColumn<DateTime>)
                return columns;
            }
            
        }
        public GCustomReportInitializer(GView view, DateTime dateStart, ICollection<GCustomMetric> metrics, ICollection<GCustomDimension> dimensions)
        {
            
            this.View = view;
            this.Dimensions = dimensions;
            this.Metrics = metrics;
            this.DateStart = dateStart;
            this.DateEnd = dateStart;
        }
        public GCustomReportInitializer( GView view, DateTime dateStart, DateTime dateEnd, ICollection<GCustomMetric> metrics, ICollection<GCustomDimension> dimensions)
        {
            this.View = view;
            this.Dimensions = dimensions;
            this.Metrics = metrics;
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
        }
        public GCustomReportInitializer(GView view, DateTime dateStart, ICollection<string> metrics)
        {
            this.View = view;
            this.Dimensions = new GCustomDimension[0];
            this.Metrics = metrics.Select(x=>new GCustomMetric(x)).ToArray();
            this.DateStart = dateStart;
            this.DateEnd = dateStart;
        }
        public GCustomReportInitializer(GView view, DateTime dateStart, ICollection<string> metrics, ICollection<string> dimensions)
        {
            this.View = view;
            this.Dimensions = dimensions.Select(x => new GCustomDimension(x)).ToArray();
            this.Metrics = metrics.Select(x => new GCustomMetric(x)).ToArray();
            this.DateStart = dateStart;
            this.DateEnd = dateStart;
        }
        public GCustomReportInitializer(GView view, DateTime dateStart, DateTime dateEnd, ICollection<string> metrics)
        {
            this.View = view;
            this.Dimensions = new GCustomDimension[0];
            this.Metrics = metrics.Select(x => new GCustomMetric(x)).ToArray();
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
        }
        public GCustomReportInitializer(GView view, DateTime dateStart, DateTime dateEnd, ICollection<string> metrics, ICollection<string> dimensions)
        {
            this.View = view;
            this.Dimensions = dimensions.Select(x => new GCustomDimension(x)).ToArray();
            this.Metrics = metrics.Select(x => new GCustomMetric(x)).ToArray();
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
        }

    }
}

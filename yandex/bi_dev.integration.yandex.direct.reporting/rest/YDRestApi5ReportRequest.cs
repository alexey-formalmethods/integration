using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.direct.reporting.rest
{
    public class YDRestApi5ReportRequest
    {
        [JsonProperty(PropertyName = "params")]
        public YDRestApi5ReportRequestParams Params { get; set; }

        

    }
    public class YDRestApi5ReportRequestParams
    {
        [JsonProperty(PropertyName = "SelectionCriteria")]
        public YDRestApi5ReportRequestParamsSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty(PropertyName = "FieldNames")]
        public ICollection<string> FieldNames { get; set; }

        [JsonProperty(PropertyName = "ReportType")]
        public string ReportType { get; set; }

        [JsonProperty(PropertyName = "DateRangeType")]
        public string DateRangeType { get => "CUSTOM_DATE"; }

        public string ReportName { get => $"SP:{this.ReportType}:{string.Join(",", FieldNames)}:{SelectionCriteria.DateFrom}={SelectionCriteria.DateTo}"; }

        [JsonProperty(PropertyName = "Format")]
        public string Format { get => "TSV"; }

        [JsonIgnore]
        public bool IncludeVAT { get; set; }
        [JsonProperty(PropertyName = "IncludeVAT")]
        public string IncludeVATString { get { return (this.IncludeVAT) ? "YES" : "NO"; } }
    }
    public class YDRestApi5ReportRequestParamsSelectionCriteria
    {
        [JsonProperty(PropertyName = "DateFrom")]
        public string DateFrom { get; set; }

        [JsonProperty(PropertyName = "DateTo")]
        public string DateTo { get; set; }
    }
}

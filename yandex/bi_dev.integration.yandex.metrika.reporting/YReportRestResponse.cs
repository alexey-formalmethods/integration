using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public class ReportRestResponse
    {
		[JsonProperty(PropertyName = "query")]
		public YReportRestResponseRequest Request { get; set; }

		[JsonProperty(PropertyName = "data")]
		public ICollection<ReportRestRequestDataRow> Rows { get; set; }
	}
	
	public class ReportRestRequestDataRow
	{
		[JsonProperty(PropertyName = "dimensions")]
		public ReportRestRequestDataRowDimension [] Dimensions { get; set; }

		[JsonProperty(PropertyName = "metrics")]
		public decimal? []  Metrics { get; set; }
	}
	public class ReportRestRequestDataRowDimension
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
	}
	
	public class YReportRestResponseRequest
	{
		[JsonProperty(PropertyName = "dimensions")]
		public string [] Dimensions { get; set; }

		[JsonProperty(PropertyName = "metrics")]
		public string [] Metrics { get; set; }
	}

}

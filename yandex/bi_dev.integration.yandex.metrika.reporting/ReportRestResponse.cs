using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.yandex.metrika.reporting
{
    public class ReportRestResponse
    {
		[JsonProperty(PropertyName = "query")]
		public ReportRestResponseRequest Request { get; set; }

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
	
	public class ReportRestResponseRequest
	{
		[JsonProperty(PropertyName = "dimensions")]
		public string [] Dimensions { get; set; }

		[JsonProperty(PropertyName = "metrics")]
		public string [] Metrics { get; set; }
	}

}

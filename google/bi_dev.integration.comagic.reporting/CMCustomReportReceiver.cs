using bi_dev.integration.reporting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace bi_dev.integration.comagic.reporting
{
    public class RPCRequest
    {
        [JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRpc = "2.0";

        [JsonProperty(PropertyName = "id")]
        public string Id = DateTime.Now.ToString("yyyyMMddHHmmss");

        private string method;
        [JsonProperty(PropertyName = "method")]
        public string Method { get { return this.method; } }

        [JsonProperty(PropertyName = "params")]
        public RPCRequestBody Params { get; set; }

        public RPCRequest(string method, string accessToken, DateTime dateFrom, DateTime dateTill, ICollection<string> fields)
        {
            this.method = method;
            this.Params = new RPCRequestBody
            {
                AccessToken = accessToken,
                DateFrom = dateFrom.ToString("yyyy-MM-dd HH:mm:ss"),
                DateTill = dateTill.ToString("yyyy-MM-dd HH:mm:ss"),
                Fields = fields
            };
        }

    }
    public class RPCRequestBody
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "date_from")]
        public string DateFrom { get; set; }

        [JsonProperty(PropertyName = "date_till")]
        public string DateTill { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public ICollection<string> Fields { get; set; }
    }
    public class CMCustomReportReceiver : ICustomReportReceiver<CMCustomReport, CMCustomReportInitializer>
    {
        public CMCustomReport Get(CMCustomReportInitializer initializer)
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json; charset=UTF-8";
            RPCRequest requestObj = new RPCRequest("get.communications_report", "o0y5grqvtehjhic7c21amo11pdjm9qltyiatvdfq", new DateTime(2019, 4, 1), new DateTime(2019, 4, 2), new string[] { "ua_client_id" });
            string result = wc.UploadString("https://dataapi.comagic.ru/v2.0", JsonConvert.SerializeObject(requestObj));

        }
    }
}

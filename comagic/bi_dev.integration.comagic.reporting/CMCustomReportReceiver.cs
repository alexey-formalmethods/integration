using bi_dev.integration.comagic.auth;
using bi_dev.integration.reporting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [JsonProperty(PropertyName = "fields", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<string> Fields { get; set; }
    }

    // -----------


    public class RPCResponse<T>
    {
        [JsonProperty(PropertyName = "result")]
        public RPCResponseData<T> Result { get; set; }

        [JsonProperty(PropertyName = "error")]
        public RPCResponseError Error { get; set; }
    }
    public class RPCResponseData<T>
    {
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }
    }
    public class RPCResponseError
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }


    public class CMCustomReportReceiver : ICustomReportReceiver<CMCustomReport, CMCustomReportInitializer>
    {
        CMConfig config;
        public CMCustomReportReceiver(CMConfig config)
        {
            this.config = config;
        }
        public CMCustomReport Get(CMCustomReportInitializer initializer)
        {
            string token = new CMAuthManager().Get(new CMAuthInitializer(config.CredentialsFilePath)).AccessToken;
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json; charset=UTF-8";
            //communications_report
            //ua_client_id
            //https://dataapi.comagic.ru/v2.0
            RPCRequest requestObj = new RPCRequest($"get.{initializer.ReportType}", token, initializer.DateFrom, initializer.DateTo, initializer.NoColumnsPassed?null:initializer.Columns.Select(x=>x.Key).ToArray());
            string resultString = wc.UploadString($"{config.ApiPath}/{config.ApiVersion}", JsonConvert.SerializeObject(requestObj));
            var result = JsonConvert.DeserializeObject<RPCResponse<ICollection<Dictionary<string, object>>>>(resultString);
            if (result.Error != null) throw new WebException($"{result.Error.Code}: {result.Error.Message}");
            CMCustomReport report = new CMCustomReport(initializer);
            report.Rows = result?.Result?.Data?.Select(x => new CMCustomReportRow
            {
                Cells = x.Select(t => {
                    if (initializer.NoColumnsPassed && (!initializer.Columns.ContainsKey(t.Key)))
                    {

                        initializer.Columns.Add(t.Key, new CMCustomReportColumn(t.Key));
                    }
                    return new CustomReportCell(initializer.Columns[t.Key], (t.Value != null && (t.Value.GetType().IsClass || t.Value.GetType().IsArray)) ? JsonConvert.SerializeObject(t.Value): t.Value?.ToString());
                    }).ToArray()
            }).ToArray();
            return report;

        }
    }
}

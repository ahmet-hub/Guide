using Newtonsoft.Json;

namespace Report.Domain.Models
{
    public class ReportResponseModel
    {
        [JsonProperty("data")]
        public ReportResponse ReportResponse { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }
    }
}

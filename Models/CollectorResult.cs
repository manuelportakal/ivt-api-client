using System.Text.Json.Serialization;

namespace ivt_test.Models
{

    public class CollectorResult
    {
        [JsonPropertyName("RecordCount")]
        public int recordCount { get; set; }

        [JsonPropertyName("Result")]
        public CollectorResultDetail[] result { get; set; }
    }

    public class CollectorResultDetail
    {
        [JsonPropertyName("collectorId")]
        public string collectorId { get; set; }

        [JsonPropertyName("collector")]
        public string collector { get; set; }

        [JsonPropertyName("formId")]
        public int formId { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("type")]
        public Typelist type { get; set; }
    }

    public class Typelist
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("text")]
        public string text { get; set; }
    }

}
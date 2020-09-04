using System.Text.Json.Serialization;

namespace ivt_test.Models
{
    public class BrandResult
    {
        [JsonPropertyName("RecordCount")]
        public int recordCount { get; set; }

        [JsonPropertyName("Result")]
        public BrandResultDetail[] result { get; set; }
    }

    public class BrandResultDetail
    {
        [JsonPropertyName("brandId")]
        public int brandId { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }
    }
}
using System;
using System.Text.Json.Serialization;

namespace ivt_test.Models
{
    public class SmsandCallListResult
    {
        [JsonPropertyName("RecordCount")]
        public int recordCount { get; set; }

        [JsonPropertyName("Result")]
        public SmsandCallResultDetail[] result { get; set; }
    }

    public class SmsandCallResultDetail
    {
        [JsonPropertyName("msisdn")]
        public string msisdn { get; set; }

        [JsonPropertyName("brand")]
        public int brand { get; set; }

        [JsonPropertyName("recipientType")]
        public int recipientType { get; set; }

        [JsonPropertyName("permissiondate")]
        public DateTime permissiondate { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime createdAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime updatedAt { get; set; }
    }

    public class EmailListResult
    {
        [JsonPropertyName("RecordCount")]
        public int recordCount { get; set; }

        [JsonPropertyName("Result")]
        public EmailResultDetail[] result { get; set; }
    }

    public class EmailResultDetail
    {
        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("brand")]
        public int brand { get; set; }

        [JsonPropertyName("recipientType")]
        public int recipientType { get; set; }

        [JsonPropertyName("permissiondate")]
        public DateTime permissiondate { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime createdAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime updatedAt { get; set; }
    }
}
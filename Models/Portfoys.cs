using System;
using System.Text.Json.Serialization;

namespace ivt_test.Models
{
    public class PortfoyAccountId
    {
        [JsonPropertyName("RecordCount")]
        public int recordCount { get; set; }

        [JsonPropertyName("Result")]
        public QueryWithAccountIdResult[] result { get; set; }
    }

    public class PortfoyGsm
    {
        [JsonPropertyName("RecordCount")]
        public int recordCount { get; set; }

        [JsonPropertyName("Result")]
        public QueryWithGsmResult[] result { get; set; }
    }

    public class PortfoyEmail
    {
        [JsonPropertyName("RecordCount")]
        public int recordCount { get; set; }

        [JsonPropertyName("Result")]
        public QueryWithEmailResult[] result { get; set; }
    }

    public class PortfoyPermission
    {
        [JsonPropertyName("RecordCount")]
        public int recordCount { get; set; }

        [JsonPropertyName("Result")]
        public PortfoyPermissionDetail[] result { get; set; }
    }
    
    public class PortfoyPermissionDetail
    {
        [JsonPropertyName("dataId")]
        public int dataId { get; set; }

        [JsonPropertyName("dataKey")]
        public string dataKey { get; set; }

        [JsonPropertyName("dataType")]
        public StatusDetail dataType { get; set; }

        [JsonPropertyName("collectorId")]
        public string collectorId { get; set; }

        [JsonPropertyName("formId")]
        public int formId { get; set; }

        [JsonPropertyName("form")]
        public string form { get; set; }

        [JsonPropertyName("collector")]
        public string collector { get; set; }

        [JsonPropertyName("recordId")]
        public string recordId { get; set; }

        [JsonPropertyName("msisdnType")]
        public StatusDetail msisdnType { get; set; }

        [JsonPropertyName("msisdn")]
        public string msisdn { get; set; }

        [JsonPropertyName("sms")]
        public int sms { get; set; }

        [JsonPropertyName("callable")]
        public int callable { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("sendmail")]
        public int sendmail { get; set; }

        [JsonPropertyName("firstName")]
        public string firstName { get; set; }

        [JsonPropertyName("lastName")]
        public string lastName { get; set; }

        [JsonPropertyName("source")]
        public StatusDetail source { get; set; }

        [JsonPropertyName("permissiondate")]
        public DateTime permissiondate { get; set; }

        [JsonPropertyName("individual")]
        public bool individual { get; set; }

        [JsonPropertyName("corporate")]
        public bool corporate { get; set; }

        [JsonPropertyName("doubleOptin")]
        public int doubleOptin { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime createdAt { get; set; }

        [JsonPropertyName("confirmedAt")]
        public DateTime confirmedAt { get; set; }

        [JsonPropertyName("note")]
        public String note { get; set; }

        [JsonPropertyName("status")]
        public StatusDetail status { get; set; }

        [JsonPropertyName("brands")]
        public int[] brands { get; set; }
    }
}
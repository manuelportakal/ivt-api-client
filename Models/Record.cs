using System;
using System.Text.Json.Serialization;

namespace ivt_test.Models
{
    public class Record
    {
        [JsonPropertyName("recordId")]
        public string recordId { get; set; }

        [JsonPropertyName("msisdn")]
        public string msisdn { get; set; }

        [JsonPropertyName("sms")]
        public int sms { get; set; }

        [JsonPropertyName("call")]
        public int call { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("sendmail")]
        public int sendmail { get; set; }

        [JsonPropertyName("firstName")]
        public string firstName { get; set; }

        [JsonPropertyName("lastName")]
        public string lastName { get; set; }

        [JsonPropertyName("source")]
        public int source { get; set; }

        [JsonPropertyName("date")]
        public DateTime date { get; set; }

        [JsonPropertyName("individual")]
        public int individual { get; set; }

        [JsonPropertyName("corporate")]
        public int corporate { get; set; }

        [JsonPropertyName("note")]
        public String note { get; set; }

        [JsonPropertyName("brands")]
        public int[] brands { get; set; }
    }

    public class RecordResult
    {
        [JsonPropertyName("dataKey")]
        public string dataKey { get; set; }
    }

    public class MultiRecordResult
    {
        [JsonPropertyName("transactionId")]
        public string transactionId { get; set; }        
        
        [JsonPropertyName("collectorId")]
        public string collectorId { get; set; }        
        
        [JsonPropertyName("formId")]
        public int formId { get; set; }

        [JsonPropertyName("form")]
        public string form { get; set; }        
        
        [JsonPropertyName("collector")]
        public string collector { get; set; }

        [JsonPropertyName("sms")]
        public int sms { get; set; }

        [JsonPropertyName("call")]
        public int call { get; set; }

        [JsonPropertyName("sendmail")]
        public int sendmail { get; set; }

        [JsonPropertyName("source")]
        public int source { get; set; }

        [JsonPropertyName("brandCount")]
        public int brandCount { get; set; }        
        
        [JsonPropertyName("total")]
        public int total { get; set; }        
        
        [JsonPropertyName("msisdn")]
        public int msisdn { get; set; }        
        
        [JsonPropertyName("email")]
        public int email { get; set; }        
        
        [JsonPropertyName("status")]
        public StatusDetail status { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime createdAt { get; set; }        
        
        [JsonPropertyName("endAt")]
        public DateTime endAt { get; set; }        
        
        [JsonPropertyName("errdesc")]
        public string errdesc { get; set; }        
        
        [JsonPropertyName("ip")]
        public string ip { get; set; }        
        
        [JsonPropertyName("agent")]
        public string agent { get; set; }
    }

    public class StatusDetail
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("text")]
        public string text { get; set; }
    }
}
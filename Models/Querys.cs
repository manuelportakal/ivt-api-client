using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ivt_test.Models
{
    public class QueryWithEmail
    {
        [JsonPropertyName("RecordCount")]
        public int recordCount { get; set; }

        [JsonPropertyName("Result")]
        public QueryWithEmailResult[] result { get; set; }

        [JsonPropertyName("NotFound")]
        public string[] NotFound { get; set; }
    }

    public class QueryWithEmailResult
    {
        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("recordId")]
        public string recordId { get; set; }

        [JsonPropertyName("firstName")]
        public string firstName { get; set; }

        [JsonPropertyName("lastName")]
        public string lastName { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime createdAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime updatedAt { get; set; }

        [JsonPropertyName("detail")]
        public QueryWithEmailResultDetail[] detail { get; set; }
    }

    public class QueryWithEmailResultDetail
    {
        [JsonPropertyName("brandId")]
        public int brandId { get; set; }

        [JsonPropertyName("recipientType")]
        public int recipientType { get; set; }

        [JsonPropertyName("sendmail")]
        public int sendmail { get; set; }

        [JsonPropertyName("source")]
        public int source { get; set; }

        [JsonPropertyName("permissiondate")]
        public Int64 permissiondate { get; set; }

        [JsonPropertyName("createdAt")]
        public Int64 createdAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public Int64 updatedAt { get; set; }
    }


    public class QueryWithGsm
    {
        [JsonPropertyName("RecordCount")]
        public int recordCount { get; set; }

        [JsonPropertyName("Result")]
        public QueryWithGsmResult[] result { get; set; }

        [JsonPropertyName("NotFound")]
        public string[] NotFound { get; set; }
    }

    public class QueryWithGsmResult
    {
        [JsonPropertyName("msisdn")]
        public string msisdn { get; set; }

        [JsonPropertyName("recordId")]
        public string recordId { get; set; }

        [JsonPropertyName("firstName")]
        public string firstName { get; set; }

        [JsonPropertyName("lastName")]
        public string lastName { get; set; }

        [JsonPropertyName("msisdnType")]
        public QueryWithGsmResultMsisdnDetail msisdnType { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime createdAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime updatedAt { get; set; }

        [JsonPropertyName("detail")]
        public QueryWithGsmResultDetail[] detail { get; set; }
    }

    public class QueryWithGsmResultMsisdnDetail
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("text")]
        public string text { get; set; }
    }

    public class QueryWithGsmResultDetail
    {
        [JsonPropertyName("brandId")]
        public int brandId { get; set; }

        [JsonPropertyName("recipientType")]
        public int recipientType { get; set; }

        [JsonPropertyName("sms")]
        public int sms { get; set; }

        [JsonPropertyName("callable")]
        public int callable { get; set; }

        [JsonPropertyName("source")]
        public int source { get; set; }

        [JsonPropertyName("permissiondate")]
        public Int64 permissiondate { get; set; }

        [JsonPropertyName("createdAt")]
        public Int64 createdAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public Int64 updatedAt { get; set; }
    }

    public class QueryWithAccountId
    {
        [JsonPropertyName("RecordCount")]
        public int recordCount { get; set; }

        [JsonPropertyName("Result")]
        public QueryWithAccountIdResult[] result { get; set; }

        [JsonPropertyName("NotFound")]
        public string[] NotFound { get; set; }
    }

    public class QueryWithAccountIdResult
    {
        [JsonPropertyName("recordId")]
        public string recordId { get; set; }

        [JsonPropertyName("firstName")]
        public string firstName { get; set; }

        [JsonPropertyName("lastName")]
        public string lastName { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime createdAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime updatedAt { get; set; }

        [JsonPropertyName("detail")]
        public QueryWithAccountIdResultDetail detail { get; set; }
    }

    public class QueryWithAccountIdResultDetail
    {
        [JsonPropertyName("msisdn")]
        public Dictionary<string, GsmResultDetail[]>  msisdn { get; set; }

        [JsonPropertyName("email")]
        public Dictionary<string, QueryWithEmailResultDetail[]> email { get; set; }
    }
    
    /// <summary>
    /// Propertynameler dinamik yapılacak
    //public class QueryWithAccountIdResultMsisdnDetail
    //{
    ///// </summary>
    //    public GsmResultDetail[] telno { get; set; }
    //}

    //public class QueryWithAccountIdResultEmailDetail
    //{
    //    public QueryWithEmailResultDetail[] mailadresi { get; set; }
    //}

    public class GsmResultDetail
    {
        [JsonPropertyName("brandId")]
        public int brandId { get; set; }

        [JsonPropertyName("recipientType")]
        public int recipientType { get; set; }

        [JsonPropertyName("sms")]
        public int sms { get; set; }

        [JsonPropertyName("callable")]
        public int callable { get; set; }

        [JsonPropertyName("source")]
        public int source { get; set; }

        [JsonPropertyName("permissiondate")]
        public Int64 permissiondate { get; set; }

        [JsonPropertyName("createdat")]
        public Int64 createdat { get; set; }

        [JsonPropertyName("updatedAt")]
        public Int64 updatedAt { get; set; }
    }
}
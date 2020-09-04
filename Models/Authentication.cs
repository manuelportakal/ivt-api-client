using System.Text.Json.Serialization;


namespace ivt_test.Controllers
{
    public class Authentication
    {
        [JsonPropertyName("access_token")]
        public string access_token { get; set; }

        [JsonPropertyName("expires_in")]
        public int expires_in { get; set; }

        [JsonPropertyName("scope")]
        public string[] scope { get; set; }

        [JsonPropertyName("token_type")]
        public string token_type { get; set; }
    }
}

using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.OAuth
{
    public class TraktDeviceCodeResponse
    {
        /// <summary>The OAuth access token</summary>
        [JsonProperty(PropertyName = "device_code")]
        public string DeviceCode { get; set; }

        /// <summary>The type of the OAuth token</summary>
        [JsonProperty(PropertyName = "user_code")]
        public string UserCode { get; set; }

        /// <summary>The date when the OAuth token will expire</summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>The OAuth refresh token</summary>
        [JsonProperty(PropertyName = "verification_url")]
        public string VerificationUrl { get; set; }

        /// <summary>The scope of the OAuth token</summary>
        [JsonProperty(PropertyName = "interval")]
        public int Interval { get; set; }
    }
}
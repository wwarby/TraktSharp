using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.OAuth
{
    public class TraktDeviceCodeRequestBody
    {
        /// <summary>Get this from your app settings</summary>
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }
    }
}
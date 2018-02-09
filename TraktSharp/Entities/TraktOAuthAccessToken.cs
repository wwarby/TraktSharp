using Newtonsoft.Json;
using System;

namespace TraktSharp.Entities {

    /// <summary>An OAuth access token issued by the Trakt API</summary>
    [Serializable]
    public class TraktOAuthAccessToken {

        /// <summary>The access token</summary>
        public string AccessToken { get; set; }

        /// <summary>The refresh token</summary>
        public string RefreshToken { get; set; }

        /// <summary>The scope of access provided by the access token</summary>
        public string AccessScope { get; set; }

        /// <summary>The UTC date when the access token expires</summary>
        public DateTimeOffset? AccessTokenExpires { get; set; }

        /// <summary>Tests if the token is valid</summary>
        [JsonIgnore]
        public bool IsValid { get { return !string.IsNullOrEmpty(AccessToken) && AccessTokenExpires >= DateTime.UtcNow; } }
    }
}
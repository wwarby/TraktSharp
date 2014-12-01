using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A response sent by the trakt API with a 409: Conflict HTTP header. Indicates that the requested resource has already been previously created.</summary>
	[Serializable]
	public class TraktConflictErrorResponse {

		/// <summary>Indicates when the conflicting resource will expire and the request can be resubmitted</summary>
		[JsonProperty(PropertyName = "expires_at")]
		public DateTime? ExpiresAt { get; set; }

	}

}
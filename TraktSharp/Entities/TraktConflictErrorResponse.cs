using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktConflictErrorResponse {

		[JsonProperty(PropertyName = "expires_at")]
		public DateTime? ExpiresAt { get; set; }

	}

}
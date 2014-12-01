using System;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Indicates the requirement for OAuth authentication on a request type</summary>
	public enum OAuthRequirement {
		/// <summary>Including authentication headers will not cause an error, but they serve no purpose in this context</summary>
		NotRequired,
		/// <summary>Request type allows authentication headers, but they are optional</summary>
		Optional,
		/// <summary>Request type requires authentication headers</summary>
		Required,
		/// <summary>Request type does not allow authentication headers</summary>
		Forbidden
	}

}
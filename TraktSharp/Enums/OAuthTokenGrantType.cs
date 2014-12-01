using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>OAuth authentication token grant type</summary>
	public enum OAuthTokenGrantType {
		/// <summary>OAuth authorization code grant type</summary>
		[Description("authorization_code")]
		AuthorizationCode,
		/// <summary>OAuth refresh token grant type</summary>
		[Description("refresh_token")]
		RefreshToken
	}

	// ReSharper restore InconsistentNaming
}
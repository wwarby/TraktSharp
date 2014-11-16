using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp {

	public enum OAuthTokenGrantType {
		[Description("authorization_code")]
		AuthorizationCode,
		[Description("refresh_token")]
		RefreshToken
	}

	public enum ExtendedOptions {
		[Description("")]
		Unspecified,
		[Description("min")]
		Min,
		[Description("images")]
		Images,
		[Description("full")]
		Full,
		[Description("full,images")]
		FullAndImages
	}

	public enum OAuthRequirementOptions {
		NotRequired,
		Optional,
		Required,
		Forbidden
	}

}
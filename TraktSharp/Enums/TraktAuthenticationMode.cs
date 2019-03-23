using System;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the method of authentication to the Trakt API</summary>
	public enum TraktAuthenticationMode {
		/// <summary>Authenticate using OAuth. This is the default authentication method.</summary>
		OAuth,
		/// <summary>
		/// Authentication using simple token headers. This is a special case where the application will
		/// is allowed to use a simpler token based authentication instead of OAuth. In order to fall under
		/// this special use case, you will need to contact the trakt staff and get a special allowance made.
		/// </summary>
		Simple
	}

}
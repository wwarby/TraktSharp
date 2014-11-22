using System;
using System.Linq;

namespace TraktSharp.Request.Auth {

	public class TraktAuthLogoutRequest : TraktDeleteRequest {

		public TraktAuthLogoutRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "auth/logout"; } }

	}

}
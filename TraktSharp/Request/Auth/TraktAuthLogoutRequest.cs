using System;
using System.Linq;

namespace TraktSharp.Request.Auth {

	internal class TraktAuthLogoutRequest : TraktDeleteRequest {

		internal TraktAuthLogoutRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "auth/logout";

  }

}
using System;
using System.Linq;

namespace TraktSharp.Request.Users {

	internal class TraktUsersUnfollowRequest : TraktDeleteByUsernameRequest {

		internal TraktUsersUnfollowRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/follow";

  }

}
using System;
using System.Linq;

namespace TraktSharp.Request.Users {

	public class TraktUsersUnfollowRequest : TraktDeleteByUsernameRequest {

		public TraktUsersUnfollowRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/follow"; } }

	}

}
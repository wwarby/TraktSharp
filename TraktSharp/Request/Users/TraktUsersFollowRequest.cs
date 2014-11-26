using System;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	public class TraktUsersFollowRequest : TraktBodylessPostByUsernameRequest<TraktUsersFollowResponse> {

		public TraktUsersFollowRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/follow"; } }

	}

}
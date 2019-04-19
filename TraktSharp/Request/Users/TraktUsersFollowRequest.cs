using System;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersFollowRequest : TraktBodylessPostByUsernameRequest<TraktUsersFollowResponse> {

		internal TraktUsersFollowRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/follow";

	}

}
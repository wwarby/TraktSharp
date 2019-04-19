using System.Collections.Generic;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersFollowingRequest : TraktGetByUsernameRequest<IEnumerable<TraktUsersFollowResponse>> {

		internal TraktUsersFollowingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/following";

	}

}
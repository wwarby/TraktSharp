using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersFollowingRequest : TraktGetByUsernameRequest<IEnumerable<TraktUsersFollowResponse>> {

		internal TraktUsersFollowingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/following"; } }

	}

}
using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersFollowersRequest : TraktGetByUsernameRequest<IEnumerable<TraktUsersFollowResponse>> {

		internal TraktUsersFollowersRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/followers"; } }

	}

}
using System;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersWatchingRequest : TraktGetByUsernameRequest<TraktUsersWatchingResponse> {

		internal TraktUsersWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/watching"; } }

	}

}
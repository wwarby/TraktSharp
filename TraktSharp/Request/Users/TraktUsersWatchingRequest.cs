using System;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	public class TraktUsersWatchingRequest : TraktGetByUsernameRequest<TraktUsersWatchingResponse> {

		public TraktUsersWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/watching"; } }

	}

}
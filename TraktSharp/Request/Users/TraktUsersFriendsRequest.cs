using System.Collections.Generic;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersFriendsRequest : TraktGetByUsernameRequest<IEnumerable<TraktUsersFriendsResponseItem>> {

		internal TraktUsersFriendsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/friends";

	}

}
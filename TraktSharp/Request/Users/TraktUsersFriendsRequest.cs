using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersFriendsRequest : TraktGetByUsernameRequest<IEnumerable<TraktUsersFriendsResponseItem>> {

		internal TraktUsersFriendsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/friends";

  }

}
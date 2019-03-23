using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersWatchedShowsRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchedShowsResponseItem>> {

		internal TraktUsersWatchedShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/watched/shows";

  }

}
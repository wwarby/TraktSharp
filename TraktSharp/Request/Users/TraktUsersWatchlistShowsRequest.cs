using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersWatchlistShowsRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchlistShowsResponseItem>> {

		internal TraktUsersWatchlistShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/watchlist/shows";

	}

}
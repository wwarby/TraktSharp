using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersWatchlistMoviesRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchlistMoviesResponseItem>> {

		internal TraktUsersWatchlistMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/watchlist/movies";

	}

}
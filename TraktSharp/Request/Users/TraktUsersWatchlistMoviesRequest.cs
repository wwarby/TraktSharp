using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	public class TraktUsersWatchlistMoviesRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchlistMoviesResponseItem>> {

		public TraktUsersWatchlistMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/watchlist/movies"; } }

	}

}
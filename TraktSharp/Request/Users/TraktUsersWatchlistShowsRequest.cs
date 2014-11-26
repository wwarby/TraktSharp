using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	public class TraktUsersWatchlistShowsRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchlistShowsResponseItem>> {

		public TraktUsersWatchlistShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/watchlist/shows"; } }

	}

}
using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	public class TraktUsersWatchlistSeasonsRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchlistSeasonsResponseItem>> {

		public TraktUsersWatchlistSeasonsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/watchlist/seasons"; } }

	}

}
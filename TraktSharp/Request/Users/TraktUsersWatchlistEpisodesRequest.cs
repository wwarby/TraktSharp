using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	public class TraktUsersWatchlistEpisodesRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchlistEpisodesResponseItem>> {

		public TraktUsersWatchlistEpisodesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/watchlist/episodes"; } }

	}

}
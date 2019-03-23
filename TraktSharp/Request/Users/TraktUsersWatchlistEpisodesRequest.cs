using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersWatchlistEpisodesRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchlistEpisodesResponseItem>> {

		internal TraktUsersWatchlistEpisodesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/watchlist/episodes";

  }

}
using System.Collections.Generic;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersWatchlistSeasonsRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchlistSeasonsResponseItem>> {

		internal TraktUsersWatchlistSeasonsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/watchlist/seasons";

	}

}
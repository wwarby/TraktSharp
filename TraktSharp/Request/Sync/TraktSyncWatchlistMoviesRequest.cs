using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncWatchlistMoviesRequest : TraktGetRequest<IEnumerable<TraktWatchlistMoviesResponseItem>> {

		internal TraktSyncWatchlistMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "sync/watchlist/movies";

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

  }

}
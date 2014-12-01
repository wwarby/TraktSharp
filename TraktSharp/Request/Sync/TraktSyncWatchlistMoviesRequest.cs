using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	public class TraktSyncWatchlistMoviesRequest : TraktGetRequest<IEnumerable<TraktWatchlistMoviesResponseItem>> {

		public TraktSyncWatchlistMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/watchlist/movies"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Required; } }

	}

}
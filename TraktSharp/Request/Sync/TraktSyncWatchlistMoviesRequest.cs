using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncWatchlistMoviesRequest : TraktGetRequest<IEnumerable<TraktSyncWatchlistMoviesResponseItem>> {

		public TraktSyncWatchlistMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/watchlist/movies"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
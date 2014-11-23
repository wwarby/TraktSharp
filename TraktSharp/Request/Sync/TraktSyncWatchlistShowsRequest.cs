using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncWatchlistShowsRequest : TraktGetRequest<IEnumerable<TraktSyncWatchlistShowsResponseItem>> {

		public TraktSyncWatchlistShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/watchlist/shows"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
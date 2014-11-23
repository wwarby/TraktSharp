using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncWatchlistSeasonsRequest : TraktGetRequest<IEnumerable<TraktSyncWatchlistSeasonsResponseItem>> {

		public TraktSyncWatchlistSeasonsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/watchlist/seasons"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
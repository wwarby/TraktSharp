using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncWatchlistEpisodesRequest : TraktGetRequest<IEnumerable<TraktSyncWatchlistEpisodesResponseItem>> {

		public TraktSyncWatchlistEpisodesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/watchlist/episodes"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
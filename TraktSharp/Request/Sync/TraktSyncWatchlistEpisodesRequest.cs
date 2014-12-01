using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	public class TraktSyncWatchlistEpisodesRequest : TraktGetRequest<IEnumerable<TraktWatchlistEpisodesResponseItem>> {

		public TraktSyncWatchlistEpisodesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/watchlist/episodes"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
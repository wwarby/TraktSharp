using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncWatchlistEpisodesRequest : TraktGetRequest<IEnumerable<TraktWatchlistEpisodesResponseItem>> {

		internal TraktSyncWatchlistEpisodesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/watchlist/episodes"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Required; } }

	}

}
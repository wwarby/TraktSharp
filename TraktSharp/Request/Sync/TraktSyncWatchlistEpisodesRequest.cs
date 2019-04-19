using System.Collections.Generic;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncWatchlistEpisodesRequest : TraktGetRequest<IEnumerable<TraktWatchlistEpisodesResponseItem>> {

		internal TraktSyncWatchlistEpisodesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "sync/watchlist/episodes";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

  }

}
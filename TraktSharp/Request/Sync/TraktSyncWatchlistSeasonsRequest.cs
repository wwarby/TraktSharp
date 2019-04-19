using System.Collections.Generic;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncWatchlistSeasonsRequest : TraktGetRequest<IEnumerable<TraktWatchlistSeasonsResponseItem>> {

		internal TraktSyncWatchlistSeasonsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "sync/watchlist/seasons";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

  }

}
using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncWatchlistShowsRequest : TraktGetRequest<IEnumerable<TraktWatchlistShowsResponseItem>> {

		internal TraktSyncWatchlistShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "sync/watchlist/shows";

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

  }

}
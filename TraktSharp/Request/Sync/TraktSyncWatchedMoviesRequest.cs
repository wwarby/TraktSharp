using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncWatchedMoviesRequest : TraktGetRequest<IEnumerable<TraktSyncWatchedMoviesResponseItem>> {

		public TraktSyncWatchedMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/history/movies"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
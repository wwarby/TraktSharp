using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Sync {

	public class TraktSyncWatchedMoviesRequest : TraktGetRequest<IEnumerable<TraktWatchedMoviesResponseItem>> {

		public TraktSyncWatchedMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/history/movies"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
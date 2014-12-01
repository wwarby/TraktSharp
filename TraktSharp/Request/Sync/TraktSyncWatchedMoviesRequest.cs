using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	public class TraktSyncWatchedMoviesRequest : TraktGetRequest<IEnumerable<TraktWatchedMoviesResponseItem>> {

		public TraktSyncWatchedMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/watched/movies"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
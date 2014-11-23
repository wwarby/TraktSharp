using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncCollectionMoviesRequest : TraktGetRequest<IEnumerable<TraktSyncCollectionMoviesResponseItem>> {

		public TraktSyncCollectionMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/collection/movies"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
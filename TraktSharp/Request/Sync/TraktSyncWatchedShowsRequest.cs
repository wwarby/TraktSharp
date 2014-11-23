using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncWatchedShowsRequest : TraktGetRequest<IEnumerable<TraktSyncWatchedShowsResponseItem>> {

		public TraktSyncWatchedShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/history/shows"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
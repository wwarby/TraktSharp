using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	public class TraktSyncWatchedShowsRequest : TraktGetRequest<IEnumerable<TraktWatchedShowsResponseItem>> {

		public TraktSyncWatchedShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/watched/shows"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Required; } }

	}

}
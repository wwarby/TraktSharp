using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncCollectionShowsRequest : TraktGetRequest<IEnumerable<TraktSyncCollectionShowsResponseItem>> {

		public TraktSyncCollectionShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/collection/shows"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.Required; } }


	}

}
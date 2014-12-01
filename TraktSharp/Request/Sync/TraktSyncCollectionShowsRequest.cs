using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	public class TraktSyncCollectionShowsRequest : TraktGetRequest<IEnumerable<TraktCollectionShowsResponseItem>> {

		public TraktSyncCollectionShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/collection/shows"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
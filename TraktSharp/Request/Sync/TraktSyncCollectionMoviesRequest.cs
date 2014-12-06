using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncCollectionMoviesRequest : TraktGetRequest<IEnumerable<TraktCollectionMoviesResponseItem>> {

		internal TraktSyncCollectionMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/collection/movies"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Required; } }

	}

}
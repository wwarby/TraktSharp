using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncCollectionMoviesRequest : TraktGetRequest<IEnumerable<TraktCollectionMoviesResponseItem>> {

		internal TraktSyncCollectionMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "sync/collection/movies";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

	}

}
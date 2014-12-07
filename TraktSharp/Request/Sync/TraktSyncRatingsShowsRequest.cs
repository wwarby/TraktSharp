using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncRatingsShowsRequest : TraktGetRequest<IEnumerable<TraktRatingsShowsResponseItem>> {

		internal TraktSyncRatingsShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/ratings/shows/{rating}"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Required; } }

		internal TraktRating Rating { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"rating", Rating != TraktRating.Unspecified ? ((int)Rating).ToString(CultureInfo.InvariantCulture) : string.Empty}
			};
		}

	}

}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncRatingsMoviesRequest : TraktGetRequest<IEnumerable<TraktRatingsMoviesResponseItem>> {

		internal TraktSyncRatingsMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "sync/ratings/movies/{rating}";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

		internal TraktRating Rating { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			new Dictionary<string, string> {
				{"rating", Rating != TraktRating.Unspecified ? ((int) Rating).ToString(CultureInfo.InvariantCulture) : string.Empty}
			};

	}

}
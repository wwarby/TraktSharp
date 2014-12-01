using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	public class TraktSyncRatingsEpisodesRequest : TraktGetRequest<IEnumerable<TraktRatingsEpisodesResponseItem>> {

		public TraktSyncRatingsEpisodesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/ratings/episodes/{rating}"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Required; } }

		public TraktRating Rating { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"rating", Rating != TraktRating.RatingUnspecified ? ((int)Rating).ToString(CultureInfo.InvariantCulture) : string.Empty}
			};
		}

	}

}
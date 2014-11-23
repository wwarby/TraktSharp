using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncRatingsEpisodesRequest : TraktGetRequest<IEnumerable<TraktSyncRatingsEpisodesResponseItem>> {

		public TraktSyncRatingsEpisodesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/ratings/episodes/{rating}"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

		public Rating Rating { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"rating", Rating != Rating.RatingUnspecified ? ((int)Rating).ToString(CultureInfo.InvariantCulture) : string.Empty}
			};
		}

	}

}
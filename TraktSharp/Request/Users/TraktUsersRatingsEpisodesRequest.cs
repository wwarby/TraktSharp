using System.Collections.Generic;
using System.Globalization;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Users {

	internal class TraktUsersRatingsEpisodesRequest : TraktGetByUsernameRequest<IEnumerable<TraktRatingsEpisodesResponseItem>> {

		internal TraktUsersRatingsEpisodesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/ratings/episodes/{rating}";

    internal TraktRating Rating { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			new Dictionary<string, string> {
				{"rating", Rating != TraktRating.Unspecified ? ((int)Rating).ToString(CultureInfo.InvariantCulture) : string.Empty}
			};

	}

}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Users {

	public class TraktUsersRatingsMoviesRequest : TraktGetByUsernameRequest<IEnumerable<TraktRatingsMoviesResponseItem>> {

		public TraktUsersRatingsMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/ratings/movies/{rating}"; } }

		public TraktRating Rating { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"rating", Rating != TraktRating.RatingUnspecified ? ((int)Rating).ToString(CultureInfo.InvariantCulture) : string.Empty}
			};
		}

	}

}
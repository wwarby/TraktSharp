using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	public class TraktUsersRatingsMoviesRequest : TraktGetByUsernameRequest<IEnumerable<TraktRatingsMoviesResponseItem>> {

		public TraktUsersRatingsMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/ratings/movies/{rating}"; } }

		public Rating Rating { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"rating", Rating != Rating.RatingUnspecified ? ((int)Rating).ToString(CultureInfo.InvariantCulture) : string.Empty}
			};
		}

	}

}
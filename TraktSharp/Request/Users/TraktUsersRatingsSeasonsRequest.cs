using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;

namespace TraktSharp.Request.Users {

	public class TraktUsersRatingsSeasonsRequest : TraktGetByUsernameRequest<IEnumerable<TraktRatingsSeasonsResponseItem>> {

		public TraktUsersRatingsSeasonsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/ratings/seasons/{rating}"; } }

		public Rating Rating { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"rating", Rating != Rating.RatingUnspecified ? ((int)Rating).ToString(CultureInfo.InvariantCulture) : string.Empty}
			};
		}

	}

}
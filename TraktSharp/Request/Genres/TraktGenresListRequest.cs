using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Genres;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Genres {

	internal class TraktGenresListRequest : TraktGetRequest<IEnumerable<TraktGenresListResponseItem>> {

		internal TraktGenresListRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "genres/{type}"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

		internal TraktGenreTypeOptions Type { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"type", TraktEnumHelper.GetDescription(Type)}
			};
		}

	}

}
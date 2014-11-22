using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Request.Movies {

	[Serializable]
	public class TraktMoviesUpdatesRequest : TraktGetRequest<IEnumerable<TraktMoviesUpdatesResponseItem>> {

		public TraktMoviesUpdatesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/updates/{start_date}"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

		public DateTime? StartDate { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"start_date", StartDate.ToTraktApiFormat()}
			};
		}

		protected override bool SupportsPagination { get { return true; } }

	}

}
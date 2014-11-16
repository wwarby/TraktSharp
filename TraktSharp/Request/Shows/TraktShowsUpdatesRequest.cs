using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TraktSharp.ExtensionMethods;
using TraktSharp.Response.Shows;

namespace TraktSharp.Request.Shows {

	[Serializable]
	public class TraktShowsUpdatesRequest : TraktRequest<IEnumerable<TraktShowsUpdatesResponseItem>> {

		public TraktShowsUpdatesRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Get; } }

		protected override string PathTemplate { get { return "shows/updates/{start_date}"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

		public DateTime? StartDate { get; set; }

		protected override IDictionary<string, string> GetPathParameters(IDictionary<string, string> pathParameters) {
			return new Dictionary<string, string> {
				{ "start_date", StartDate.ToTraktApiFormat() }
			};
		}

		protected override bool SupportsPagination { get { return true; } }

	}

}
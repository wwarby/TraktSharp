using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TraktSharp.Helpers;
using TraktSharp.Response.Genres;

namespace TraktSharp.Request.Genres {

	public class TraktGenresListRequest : TraktRequest<IEnumerable<TraktGenresListResponseItem>> {

		public TraktGenresListRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Get; } }

		protected override string PathTemplate { get { return "genres/{type}"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

		protected override bool SupportsPagination { get { return false; } }

		public GenreTypeOptions Type { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{ "type", EnumsHelper.GetDescription(Type) }
			};
		}

	}

}
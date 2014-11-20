using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TraktSharp.Entities;

namespace TraktSharp.Request.Shows {

	public class TraktShowsRelatedRequest : TraktGetRequest<IEnumerable<TraktShow>> {

		public TraktShowsRelatedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/related"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

		protected override bool SupportsPagination { get { return false; } }

		public string Id { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{ "id", Id }
			};
		}

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Id)) {
				throw new ArgumentException("Id not set.");
			}
		}

	}

}
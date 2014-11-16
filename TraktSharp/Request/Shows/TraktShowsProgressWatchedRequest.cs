using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TraktSharp.Response;

namespace TraktSharp.Request.Shows {

	public class TraktShowsProgressCollectionRequest : TraktRequest<TraktShowProgress> {

		public TraktShowsProgressCollectionRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Get; } }

		protected override string PathTemplate { get { return "shows/{id}/progress/collection"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.Required; } }

		protected override bool SupportsPagination { get { return false; } }

		public string Id { get; set; }

		protected override IDictionary<string, string> GetPathParameters(IDictionary<string, string> pathParameters) {
			return new Dictionary<string, string> {
				{ "id", Id }
			};
		}

		protected override bool ValidateParameters() {
			if (string.IsNullOrEmpty(Id)) {
				throw new ArgumentException("Id not set.");
			}
			return true;
		}

	}

}
using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Shows;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	public class TraktShowsTranslationsRequest : TraktGetByIdRequest<IEnumerable<TraktShowsTranslationsResponseItem>> {

		public TraktShowsTranslationsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/translations/{language}"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

		public string Language { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return base.GetPathParameters(pathParameters).Union(new Dictionary<string, string> {
				{"language", Language},
			});
		}

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(Language)) {
				throw new ArgumentException("Language not set.");
			}
		}

	}

}
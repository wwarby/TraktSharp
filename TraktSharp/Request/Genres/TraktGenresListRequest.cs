using System.Collections.Generic;
using TraktSharp.Entities.Response.Genres;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Genres {

	internal class TraktGenresListRequest : TraktGetRequest<IEnumerable<TraktGenresListResponseItem>> {

		internal TraktGenresListRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "genres/{type}";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

    internal TraktGenreTypeOptions Type { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			new Dictionary<string, string> {
				{"type", TraktEnumHelper.GetDescription(Type)}
			};

	}

}
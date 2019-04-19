using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Search {

	internal class TraktIdLookupRequest : TraktGetByIdRequest<IEnumerable<TraktSearchResult>> {

		internal TraktIdLookupRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "search";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

		protected override bool SupportsPagination => true;

    internal TraktIdLookupType IdType { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetQueryStringParameters(Dictionary<string, string> queryStringParameters) =>
			base.GetPathParameters(queryStringParameters).Union(new Dictionary<string, string> {
				{"id_type", TraktEnumHelper.GetDescription(IdType)}
			});

	}

}
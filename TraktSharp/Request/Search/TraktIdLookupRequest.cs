using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Search {

	internal class TraktIdLookupRequest : TraktGetByIdRequest<IEnumerable<TraktSearchResult>> {

		internal TraktIdLookupRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "search"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

		protected override bool SupportsPagination { get { return true; } }

		internal TraktIdLookupType IdType { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetQueryStringParameters(Dictionary<string, string> queryStringParameters) {
			return base.GetPathParameters(queryStringParameters).Union(new Dictionary<string, string> {
				{"id_type", TraktEnumHelper.GetDescription(IdType)}
			});
		}

	}

}
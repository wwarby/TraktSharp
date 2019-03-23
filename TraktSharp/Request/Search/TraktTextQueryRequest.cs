using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Search {

	internal class TraktTextQueryRequest : TraktGetRequest<IEnumerable<TraktSearchResult>> {

		internal TraktTextQueryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "search";

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

    protected override bool SupportsPagination => true;

    internal string Query { get; set; }

		internal TraktSearchItemType Type { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetQueryStringParameters(Dictionary<string, string> queryStringParameters) {
			var ret = base.GetQueryStringParameters(queryStringParameters).ToDictionary(o => o.Key, o => o.Value);
			ret["query"] = Query;
			if (Type != TraktSearchItemType.Unspecified) {
				ret["type"] = TraktEnumHelper.GetDescription(Type);
			}
			return ret;
		}

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Query)) {
				throw new ArgumentException("Query not set.");
			}
		}

	}

}
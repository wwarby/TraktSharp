using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Search {

	public class TraktTextQueryRequest : TraktGetRequest<IEnumerable<TraktSearchResult>> {

		public TraktTextQueryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "search"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

		protected override bool SupportsPagination { get { return true; } }

		public string Query { get; set; }

		public TextQueryType Type { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetQueryStringParameters(Dictionary<string, string> queryStringParameters) {
			var ret = base.GetQueryStringParameters(queryStringParameters).ToDictionary(o => o.Key, o => o.Value);
			ret["query"] = Query;
			if (Type != TextQueryType.Unspecified) {
				ret["type"] = EnumsHelper.GetDescription(Type);
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
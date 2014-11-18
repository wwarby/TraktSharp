using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TraktSharp.Helpers;
using TraktSharp.Response;

namespace TraktSharp.Request.Search {

	public class TraktIdLookupRequest : TraktRequest<IEnumerable<TraktSearchResult>> {

		public TraktIdLookupRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Get; } }

		protected override string PathTemplate { get { return "search"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

		protected override bool SupportsPagination { get { return true; } }

		public string Id { get; set; }

		public IdLookupTypeOptions IdType { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetQueryStringParameters(Dictionary<string, string> queryStringParameters) {
			var ret = base.GetQueryStringParameters(queryStringParameters).ToDictionary(o => o.Key, o => o.Value);
			ret["id_type"] = EnumsHelper.GetDescription(IdType);
			ret["id"] = Id;
			return ret;
		}

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Id)) { throw new ArgumentException("Id not set."); }
		}

	}

}
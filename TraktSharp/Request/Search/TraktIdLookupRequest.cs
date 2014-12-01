using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Search {

	public class TraktIdLookupRequest : TraktGetByIdRequest<IEnumerable<TraktSearchResult>> {

		public TraktIdLookupRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "search"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

		protected override bool SupportsPagination { get { return true; } }

		public IdLookupType IdType { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetQueryStringParameters(Dictionary<string, string> queryStringParameters) {
			return base.GetPathParameters(queryStringParameters).Union(new Dictionary<string, string> {
				{"id_type", EnumsHelper.GetDescription(IdType)}
			});
		}

	}

}
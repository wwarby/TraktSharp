using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.Search;

namespace TraktSharp.Modules {

	public class TraktSearchModule : TraktModuleBase {

		public TraktSearchModule(TraktClient client) : base(client) { }

		public async Task<IEnumerable<TraktSearchResult>> TextQueryAsync(string query, TextQueryType queryType = TextQueryType.Unspecified, ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktTextQueryRequest(Client) {
				Query = query,
				Type = queryType,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			});
		}

		public async Task<IEnumerable<TraktSearchResult>> IdLookupAsync(string id, IdLookupType idType, ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktIdLookupRequest(Client) {
				IdType = idType,
				Id = id,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			});
		}

	}

}
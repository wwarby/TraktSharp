using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Request.Search;
using TraktSharp.Response;

namespace TraktSharp.Modules {

	public class TraktSearch {

		public TraktSearch(TraktClient client) {
			Client = client;
		}

		public TraktClient Client { get; private set; }

		public async Task<IEnumerable<TraktSearchResult>> TextQueryAsync(string query, TextQueryTypeOptions type = TextQueryTypeOptions.Unspecified, ExtendedOptions extended = ExtendedOptions.Unspecified, int? page = null, int? limit = null) {
			return await new TraktTextQueryRequest(Client) {
				Query = query,
				Type = type,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktSearchResult>> IdLookupAsync(IdLookupTypeOptions idType, string id, ExtendedOptions extended = ExtendedOptions.Unspecified, int? page = null, int? limit = null) {
			return await new TraktIdLookupRequest(Client) {
				IdType = idType,
				Id = id,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

	}

}
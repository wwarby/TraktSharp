using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Request.Search;
using TraktSharp.Structs;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Search namespace</summary>
	public class TraktSearchModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktSearchModule(TraktClient client) : base(client) { }

		/// <summary>Perform a text query that searches titles, descriptions, translated titles, aliases, and people. Items searched include movies, shows, episodes, people, and lists. Results are ordered by the most relevant score.</summary>
		/// <param name="query">The search term (free text)</param>
		/// <param name="queryType">Constrain the query to a specified type</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktSearchResult>> TextQueryAsync(string query, TraktSearchItemType queryType = TraktSearchItemType.Unspecified, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktTextQueryRequest(Client) {
				Query = query,
				Type = queryType,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});
		}

		/// <summary>Lookup an item by using a trakt ID or other external ID. This is helpful to get an items info including the trakt ID.</summary>
		/// <param name="id">The ID to search for</param>
		/// <param name="idType">The type of ID to search for</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktSearchResult>> IdLookupAsync(string id, TraktIdLookupType idType, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktIdLookupRequest(Client) {
				IdType = idType,
				Id = id,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});
		}

	}

}
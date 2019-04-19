using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Enums;
using TraktSharp.Request.Sync;

namespace TraktSharp.Modules {
	/// <summary>Provides API methods in the Sync namespace</summary>
	public partial class TraktSyncModule {
		/// <summary>
		/// Returns movies and episodes that a user has watched, sorted by most recent. 
		/// </summary>
		/// <param name="page">Page to fetch (Based on Limit size)</param>
		/// <param name="limit">Limit per Page</param>
		/// <returns></returns>
		public async Task<IEnumerable<TraktSyncHistoryResponse>> GetHistoryAsync(int? page = null, int? limit = null)
			=> await SendAsync(new TraktSyncHistoryRequest(Client, TraktHistoryItemType.Unspecified, 0, page, limit));

		/// <summary>
		/// Returns movies and episodes that a user has watched, sorted by most recent. 
		/// </summary>
		/// <param name="type">Media object type</param>
		/// <param name="id">Media object ID to get history for.</param>
		/// <param name="page">Page to fetch (Based on Limit size)</param>
		/// <param name="limit">Limit per Page</param>
		/// <returns></returns>
		public async Task<IEnumerable<TraktSyncHistoryResponse>> GetHistoryAsync(
			TraktHistoryItemType type,
			int? id = null,
			int? page = null,
			int? limit = null
		) => await SendAsync(new TraktSyncHistoryRequest(Client, type, id, page, limit));

		/// <summary>
		/// Returns movies and episodes that a user has watched, sorted by most recent. 
		/// </summary>
		/// <param name="type">Media object type</param>
		/// <param name="from">What date to fetch history from</param>
		/// <param name="to">What date to stop fetching history from</param>
		/// <param name="id">Media object ID to get history for.</param>
		/// <param name="page">Page to fetch (Based on Limit size)</param>
		/// <param name="limit">Limit per Page</param>
		/// <returns></returns>
		public async Task<IEnumerable<TraktSyncHistoryResponse>> GetHistoryAsync(
			TraktHistoryItemType type,
			DateTimeOffset? from = null,
			DateTimeOffset? to = null,
			int? id = null,
			int? page = null,
			int? limit = null
		) => await SendAsync(new TraktSyncHistoryRequest(Client, type, id, page, limit, from, to));
	}
}
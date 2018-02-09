using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Enums;
using TraktSharp.Request.Sync;

namespace TraktSharp.Modules
{
    /// <summary>Provides API methods in the Sync namespace</summary>
    public partial class TraktSyncModule
    {
        /// <summary>
        /// Returns movies and episodes that a user has watched, sorted by most recent. 
        /// </summary>
        /// <param name="Page">Page to fetch (Based on Limit size)</param>
        /// <param name="Limit">Limit per Page</param>
        /// <returns></returns>
        public async Task<IEnumerable<TraktSyncHistoryResponse>> GetHistoryAsync(int? Page = null, int? Limit = null)
        {
            return await SendAsync(new TraktSyncHistoryRequest(Client, TraktHistoryItemType.Unspecified, 0, Page, Limit));
        }

        /// <summary>
        /// Returns movies and episodes that a user has watched, sorted by most recent. 
        /// </summary>
        /// <param name="Type">Media object type</param>
        /// <param name="Id">Media object ID to get history for.</param>
        /// <param name="Page">Page to fetch (Based on Limit size)</param>
        /// <param name="Limit">Limit per Page</param>
        /// <returns></returns>
        public async Task<IEnumerable<TraktSyncHistoryResponse>> GetHistoryAsync(TraktHistoryItemType Type, int? Id = null, int? Page = null, int? Limit = null)
        {
            return await SendAsync(new TraktSyncHistoryRequest(Client, Type, Id, Page, Limit));
        }

        /// <summary>
        /// Returns movies and episodes that a user has watched, sorted by most recent. 
        /// </summary>
        /// <param name="Type">Media object type</param>
        /// <param name="From">What date to fetch history from</param>
        /// <param name="To">What date to stop fetching history from</param>
        /// <param name="Id">Media object ID to get history for.</param>
        /// <param name="Page">Page to fetch (Based on Limit size)</param>
        /// <param name="Limit">Limit per Page</param>
        /// <returns></returns>
        public async Task<IEnumerable<TraktSyncHistoryResponse>> GetHistoryAsync(TraktHistoryItemType Type, DateTimeOffset? From = null, DateTimeOffset? To = null, int? Id = null, int? Page = null, int? Limit = null)
        {
            return await SendAsync(new TraktSyncHistoryRequest(Client, Type, Id, Page, Limit, From, To));
        }
    }
}
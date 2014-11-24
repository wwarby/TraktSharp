using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.Response;
using TraktSharp.Entities.Response.Users;
using TraktSharp.Request.Users;

namespace TraktSharp.Modules {

	public class TraktUsersModule {

		public TraktUsersModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktUserSettings> GetSettingsAsync() {
			return await new TraktUsersSettingsRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktFollowRequest>> GetFollowRequestsAsync() {
			return await new TraktUsersRequestsRequest(Client).SendAsync();
		}

		public async Task<TraktUsersRequestsApproveResponse> ApproveFollowRequestAsync(string requestId) {
			return await new TraktUsersRequestsApproveRequest(Client) { Id = requestId }.SendAsync();
		}

		public async Task DenyFollowRequestAsync(string requestId) {
			await new TraktUsersRequestsDenyRequest(Client) { Id = requestId }.SendAsync();
		}

		public async Task<TraktUser> GetUser(string username, bool authenticate = true) {
			return await new TraktUsersProfileRequest(Client) { Username = username, Authenticate = authenticate }.SendAsync();
		}

		public async Task<TraktUser> GetUserCollection(string username, bool authenticate = true) {
			return await new TraktUsersProfileRequest(Client) { Username = username, Authenticate = authenticate }.SendAsync();
		}

		public async Task<IEnumerable<TraktCollectionMoviesResponseItem>> GetMoviesCollectionAsync(string username, bool authenticate = true) {
			return await new TraktUsersCollectionMoviesRequest(Client) { Username = username, Authenticate = authenticate }.SendAsync();
		}

		public async Task<IEnumerable<TraktCollectionShowsResponseItem>> GetShowsCollectionAsync(string username, bool authenticate = true) {
			return await new TraktUsersCollectionShowsRequest(Client) { Username = username, Authenticate = authenticate }.SendAsync();
		}

	}

}
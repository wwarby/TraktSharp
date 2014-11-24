using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Users;
using TraktSharp.Entities.Response;
using TraktSharp.Entities.Response.Users;
using TraktSharp.Request.Users;

namespace TraktSharp.Modules {

	public class TraktUsersModule {

		private const string _me = "me";

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

		public async Task<TraktUser> GetUserAsync(string username = _me, bool authenticate = true) {
			return await new TraktUsersProfileRequest(Client) { Username = username, Authenticate = authenticate }.SendAsync();
		}

		public async Task<IEnumerable<TraktCollectionMoviesResponseItem>> GetMoviesCollectionForUserAsync(string username = _me, bool authenticate = true) {
			return await new TraktUsersCollectionMoviesRequest(Client) { Username = username, Authenticate = authenticate }.SendAsync();
		}

		public async Task<IEnumerable<TraktCollectionShowsResponseItem>> GetShowsCollectionForUserAsync(string username = _me, bool authenticate = true) {
			return await new TraktUsersCollectionShowsRequest(Client) { Username = username, Authenticate = authenticate }.SendAsync();
		}

		public async Task<IEnumerable<TraktList>> GetListsForUserAsync(string username = _me, bool authenticate = true) {
			return await new TraktUsersListsRequest(Client) { Username = username, Authenticate = authenticate }.SendAsync();
		}

		public async Task<TraktList> CreateListAsync(string name, string description = "", PrivacyOption privacy = PrivacyOption.Unspecified, bool? displayMembers = null, bool? allowComments = null, string username = _me) {
			return await CreateListAsync(new TraktListRequestBody {
				Name = name,
				Description = description,
				Privacy = privacy,
				DisplayNumbers = displayMembers,
				AllowComments = allowComments
			}, username);
		}

		public async Task<TraktList> CreateListAsync(TraktListRequestBody list, string username = _me) {
			return await new TraktUsersListsAddRequest(Client) {
				RequestBody = list,
				Username = username
			}.SendAsync();
		}

		public async Task<TraktList> GetListAsync(TraktList list, string username = _me, bool authenticate = true) {
			return await GetListAsync(list.Ids.GetBestId(), username, authenticate);
		}

		public async Task<TraktList> GetListAsync(int listId, string username = _me, bool authenticate = true) {
			return await GetListAsync(listId.ToString(CultureInfo.InvariantCulture), username, authenticate);
		}

		public async Task<TraktList> GetListAsync(string listId, string username = _me, bool authenticate = true) {
			return await new TraktUsersListRequest(Client) {
				Id = listId,
				Username = username,
				Authenticate = authenticate
			}.SendAsync();
		}

		public async Task<TraktList> UpdateListAsync(string name, string description = "", PrivacyOption privacy = PrivacyOption.Unspecified, bool? displayMembers = null, bool? allowComments = null, string username = _me) {
			return await UpdateListAsync(new TraktListRequestBody {
				Name = name,
				Description = description,
				Privacy = privacy,
				DisplayNumbers = displayMembers,
				AllowComments = allowComments
			}, username);
		}

		public async Task<TraktList> UpdateListAsync(TraktListRequestBody list, string username = _me) {
			return await new TraktUsersListsUpdateRequest(Client) {
				RequestBody = list,
				Username = username
			}.SendAsync();
		}

		public async Task DeleteListAsync(TraktList list, string username = _me) {
			await DeleteListAsync(list.Ids.GetBestId(), username);
		}

		public async Task DeleteListAsync(int listId, string username = _me) {
			await DeleteListAsync(listId.ToString(CultureInfo.InvariantCulture), username);
		}

		public async Task DeleteListAsync(string listId, string username = _me) {
			await new TraktUsersListDeleteRequest(Client) { Id = listId, Username = username }.SendAsync();
		}

	}

}
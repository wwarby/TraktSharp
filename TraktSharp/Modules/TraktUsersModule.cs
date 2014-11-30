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

	public partial class TraktUsersModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktUsersModule(TraktClient client) : base(client) { }

		private const string _me = "me";

		public async Task<TraktUserSettings> GetSettingsAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersSettingsRequest(Client) { Extended = extended });
		}

		public async Task<object> UpdateSettingsAsync() {
			await Task.Run(() => { throw new NotImplementedException("Feature under development at Trakt"); });
			return null;
		}

		public async Task<IEnumerable<TraktFollowRequest>> GetFollowRequestsAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRequestsRequest(Client) { Extended = extended });
		}

		public async Task<TraktUsersFollowResponseItem> ApproveFollowRequestAsync(string requestId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRequestsApproveRequest(Client) { Id = requestId, Extended = extended });
		}

		public async Task DenyFollowRequestAsync(string requestId) {
			await SendAsync(new TraktUsersRequestsDenyRequest(Client) { Id = requestId });
		}

		public async Task<TraktUser> GetUserAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified, bool authenticate = true) {
			return await SendAsync(new TraktUsersProfileRequest(Client) {
				Username = username,
				Extended = extended,
				Authenticate = authenticate
			});
		}

		public async Task<IEnumerable<TraktCollectionMoviesResponseItem>> GetMoviesCollectionAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified, bool authenticate = true) {
			return await SendAsync(new TraktUsersCollectionMoviesRequest(Client) {
				Username = username,
				Extended = extended,
				Authenticate = authenticate
			});
		}

		public async Task<IEnumerable<TraktCollectionShowsResponseItem>> GetShowsCollectionAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified, bool authenticate = true) {
			return await SendAsync(new TraktUsersCollectionShowsRequest(Client) { 
				Username = username,
				Extended = extended,
				Authenticate = authenticate 
			});
		}

		public async Task<IEnumerable<TraktList>> GetListsAsync(string username = _me, bool authenticate = true) {
			return await SendAsync(new TraktUsersListsRequest(Client) { Username = username, Authenticate = authenticate });
		}

		public async Task<TraktList> CreateListAsync(string name, string description = "", PrivacyOption privacy = PrivacyOption.Unspecified, bool? displayMembers = null, bool? allowComments = null, string username = _me) {
			return await CreateListAsync(new TraktListRequestBody {
				Name = name,
				Description = description,
				Privacy = privacy,
				DisplayNumbers = displayMembers,
				AllowComments = allowComments
			});
		}

		public async Task<TraktList> CreateListAsync(TraktListRequestBody list) {
			return await SendAsync(new TraktUsersListsAddRequest(Client) {
				RequestBody = list,
				Username = _me //From Justin Nemeth: You can only create lists for yourself, for now anyway.
			});
		}

		public async Task<TraktList> GetListAsync(TraktList list, string username = _me, bool authenticate = true) {
			return await GetListAsync(list.Ids.GetBestId(), username, authenticate);
		}

		public async Task<TraktList> GetListAsync(int listId, string username = _me, bool authenticate = true) {
			return await GetListAsync(listId.ToString(CultureInfo.InvariantCulture), username, authenticate);
		}

		public async Task<TraktList> GetListAsync(string listId, string username = _me, bool authenticate = true) {
			return await SendAsync(new TraktUsersListRequest(Client) {
				Id = listId,
				Username = username,
				Authenticate = authenticate
			});
		}

		public async Task<TraktList> UpdateListAsync(string name, string description = "", PrivacyOption privacy = PrivacyOption.Unspecified, bool? displayMembers = null, bool? allowComments = null) {
			return await UpdateListAsync(new TraktListRequestBody {
				Name = name,
				Description = description,
				Privacy = privacy,
				DisplayNumbers = displayMembers,
				AllowComments = allowComments
			});
		}

		public async Task<TraktList> UpdateListAsync(TraktListRequestBody list) {
			return await SendAsync(new TraktUsersListsUpdateRequest(Client) {
				RequestBody = list,
				Username = _me //From Justin Nemeth: You can only create lists for yourself, for now anyway.
			});
		}

		public async Task DeleteListAsync(TraktList list) {
			await DeleteListAsync(list.Ids.GetBestId());
		}

		public async Task DeleteListAsync(int listId) {
			await DeleteListAsync(listId.ToString(CultureInfo.InvariantCulture));
		}

		public async Task DeleteListAsync(string listId) {
			await SendAsync(new TraktUsersListDeleteRequest(Client) { Id = listId, Username = _me }); //From Justin Nemeth: You can only create lists for yourself, for now anyway.
		}

		public async Task LikeListAsync(TraktList list, string username) {
			await LikeListAsync(list.Ids.GetBestId(), username);
		}

		public async Task LikeListAsync(int listId, string username) {
			await LikeListAsync(listId.ToString(CultureInfo.InvariantCulture), username);
		}

		public async Task LikeListAsync(string listId, string username) {
			await SendAsync(new TraktUsersListLikeRequest(Client) { Id = listId, Username = username });
		}

		public async Task UnlikeListAsync(TraktList list, string username) {
			await UnlikeListAsync(list.Ids.GetBestId(), username);
		}

		public async Task UnlikeListAsync(int listId, string username) {
			await UnlikeListAsync(listId.ToString(CultureInfo.InvariantCulture), username);
		}

		public async Task UnlikeListAsync(string listId, string username) {
			await SendAsync(new TraktUsersListLikeDeleteRequest(Client) { Id = listId, Username = username });
		}

		public async Task<IEnumerable<TraktListItemsResponseItem>> GetListItemsAsync(string listId, ExtendedOption extended = ExtendedOption.Unspecified, string username = _me, bool authenticate = true) {
			return await SendAsync(new TraktUsersListItemsRequest(Client) {
				Id = listId,
				Username = username,
				Extended = extended
			});
		}

		public async Task<TraktUsersFollowResponse> FollowAsync(string username, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersFollowRequest(Client) { Username = username, Extended = extended });
		}

		public async Task UnfollowAsync(string username) {
			await SendAsync(new TraktUsersUnfollowRequest(Client) { Username = username });
		}

		public async Task<IEnumerable<TraktUsersFollowResponseItem>> GetFollowersAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersFollowersRequest(Client) { Username = username, Extended = extended });
		}

		public async Task<IEnumerable<TraktUsersFollowResponseItem>> GetFollowingAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersFollowingRequest(Client) { Username = username, Extended = extended });
		}

		public async Task<IEnumerable<TraktUsersFriendsResponseItem>> GetFriendsAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersFriendsRequest(Client) { Username = username, Extended = extended });
		}

		public async Task<IEnumerable<TraktUsersHistoryMoviesResponseItem>> GetMoviesHistoryAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktUsersHistoryMoviesRequest(Client) {
				Username = username,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			});
		}

		public async Task<IEnumerable<TraktUsersHistoryEpisodesResponseItem>> GetEpisodesHistoryAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktUsersHistoryEpisodesRequest(Client) {
				Username = username,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			});
		}

		public async Task<IEnumerable<TraktRatingsMoviesResponseItem>> GetMovieRatingsAsync(string username = _me, Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRatingsMoviesRequest(Client) {
				Username = username,
				Rating = rating,
				Extended = extended
			});
		}

		public async Task<IEnumerable<TraktRatingsShowsResponseItem>> GetShowRatingsAsync(string username = _me, Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRatingsShowsRequest(Client) {
				Username = username,
				Rating = rating,
				Extended = extended
			});
		}

		public async Task<IEnumerable<TraktRatingsSeasonsResponseItem>> GetSeasonRatingsAsync(string username = _me, Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRatingsSeasonsRequest(Client) {
				Username = username,
				Rating = rating,
				Extended = extended
			});
		}

		public async Task<IEnumerable<TraktRatingsEpisodesResponseItem>> GetEpisodeRatingsAsync(string username = _me, Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRatingsEpisodesRequest(Client) {
				Username = username,
				Rating = rating,
				Extended = extended
			});
		}

		public async Task<IEnumerable<TraktWatchlistMoviesResponseItem>> GetWatchlistMoviesAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchlistMoviesRequest(Client) { Username = username, Extended = extended });
		}

		public async Task<IEnumerable<TraktWatchlistShowsResponseItem>> GetWatchlistShowsAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchlistShowsRequest(Client) { Username = username, Extended = extended });
		}

		public async Task<IEnumerable<TraktWatchlistSeasonsResponseItem>> GetWatchlistSeasonsAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchlistSeasonsRequest(Client) { Username = username, Extended = extended });
		}

		public async Task<IEnumerable<TraktWatchlistEpisodesResponseItem>> GetWatchlistEpisodesAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchlistEpisodesRequest(Client) { Username = username, Extended = extended });
		}

		public async Task<TraktUsersWatchingResponse> GetCurrentlyWatchingAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchingRequest(Client) { Username = username, Extended = extended });
		}

		public async Task<IEnumerable<TraktWatchedMoviesResponseItem>> GetWatchedMoviesAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchedMoviesRequest(Client) { Username = username, Extended = extended });
		}

		public async Task<IEnumerable<TraktWatchedShowsResponseItem>> GetWatchedShowsAsync(string username = _me, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchedShowsRequest(Client) { Username = username, Extended = extended });
		}

		public async Task<object> GetActivitiesAsync(string username = _me) {
			await Task.Run(() => { throw new NotImplementedException("Feature under development at Trakt"); });
			return null;
		}

		public async Task<object> GetFriendActivitiesAsync(string username = _me) {
			await Task.Run(() => { throw new NotImplementedException("Feature under development at Trakt"); });
			return null;
		}

	}

}
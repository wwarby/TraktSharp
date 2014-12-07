using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Users;
using TraktSharp.Entities.Response;
using TraktSharp.Entities.Response.Users;
using TraktSharp.Enums;
using TraktSharp.Request.Users;
using TraktSharp.Structs;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Users namespace</summary>
	public partial class TraktUsersModule : TraktModuleBase {

		private const string _me = "me";

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktUsersModule(TraktClient client) : base(client) { }

		/// <summary>Get the user's settings so you can align your app's experience with what they're used to on the trakt website</summary>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktUserSettings> GetSettingsAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersSettingsRequest(Client) { Extended = extended });
		}

		/// <summary>Update some of the user's settings</summary>
		/// <returns>See summary</returns>
		public async Task<object> UpdateSettingsAsync() {
			await Task.Run(() => { throw new NotImplementedException("Feature under development at Trakt"); });
			return null;
		}

		/// <summary>List a user's pending follow requests so they can either approve or deny them</summary>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktFollowRequest>> GetFollowRequestsAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRequestsRequest(Client) { Extended = extended });
		}

		/// <summary>Approve a follower using the id of the request. If the id is not found, was already approved, or was already denied, a 404 error will be returned.</summary>
		/// <param name="requestId">The request ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktUsersFollowResponse> ApproveFollowRequestAsync(string requestId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRequestsApproveRequest(Client) { Id = requestId, Extended = extended });
		}

		/// <summary>Deny a follower using the id of the request. If the id is not found, was already approved, or was already denied, a 404 error will be returned.</summary>
		/// <param name="requestId">The request ID</param>
		/// <returns>See summary</returns>
		public async Task DenyFollowRequestAsync(string requestId) {
			await SendAsync(new TraktUsersRequestsDenyRequest(Client) { Id = requestId });
		}

		/// <summary>Get a user's profile information. If the user is private, info will only be returned if you send OAuth and are either that user or an approved follower.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <returns>See summary</returns>
		public async Task<TraktUser> GetUserAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified, bool authenticate = true) {
			return await SendAsync(new TraktUsersProfileRequest(Client) {
				Username = username,
				Extended = extended,
				Authenticate = authenticate
			});
		}

		/// <summary>Get all collected items in a user's collection. A collected item indicates availability to watch digitally or on physical media.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktCollectionMoviesResponseItem>> GetMoviesCollectionAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified, bool authenticate = true) {
			return await SendAsync(new TraktUsersCollectionMoviesRequest(Client) {
				Username = username,
				Extended = extended,
				Authenticate = authenticate
			});
		}

		/// <summary>Get all collected items in a user's collection. A collected item indicates availability to watch digitally or on physical media.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktCollectionShowsResponseItem>> GetShowsCollectionAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified, bool authenticate = true) {
			return await SendAsync(new TraktUsersCollectionShowsRequest(Client) { 
				Username = username,
				Extended = extended,
				Authenticate = authenticate 
			});
		}

		/// <summary>Returns all custom lists for a user. Use <see cref="GetListItemsAsync"/> to get the actual items a specific list contains.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktList>> GetListsAsync(string username = _me, bool authenticate = true) {
			return await SendAsync(new TraktUsersListsRequest(Client) { Username = username, Authenticate = authenticate });
		}

		/// <summary>Create a new custom list. The name is the only required field, but the other info is recommended to ask for.</summary>
		/// <param name="name">The name of the list</param>
		/// <param name="description">Description for this list</param>
		/// <param name="privacy">Privacy setting for the list</param>
		/// <param name="displayMembers">Should each item be numbered?</param>
		/// <param name="allowComments">Are comments allowed?</param>
		/// <param name="username">The user's Trakt username</param>
		/// <returns>See summary</returns>
		public async Task<TraktList> CreateListAsync(string name, string description = "", TraktPrivacyOption privacy = TraktPrivacyOption.Unspecified, bool? displayMembers = null, bool? allowComments = null, string username = _me) {
			return await CreateListAsync(new TraktListRequestBody {
				Name = name,
				Description = description,
				Privacy = privacy,
				DisplayNumbers = displayMembers,
				AllowComments = allowComments
			});
		}

		/// <summary>Create a new custom list. The name is the only required field, but the other info is recommended to ask for.</summary>
		/// <param name="list">The list</param>
		/// <returns>See summary</returns>
		public async Task<TraktList> CreateListAsync(TraktListRequestBody list) {
			return await SendAsync(new TraktUsersListsAddRequest(Client) {
				RequestBody = list,
				Username = _me //From Justin Nemeth: You can only create lists for yourself, for now anyway.
			});
		}

		/// <summary>Returns a single custom list. Use <see cref="GetListItemsAsync"/> to get the actual items this list contains.</summary>
		/// <param name="list">The list</param>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <returns>See summary</returns>
		public async Task<TraktList> GetListAsync(TraktList list, string username = _me, bool authenticate = true) {
			return await GetListAsync(list.Ids.GetBestId(), username, authenticate);
		}

		/// <summary>Returns a single custom list. Use <see cref="GetListItemsAsync"/> to get the actual items this list contains.</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <returns>See summary</returns>
		public async Task<TraktList> GetListAsync(int listId, string username = _me, bool authenticate = true) {
			return await GetListAsync(listId.ToString(CultureInfo.InvariantCulture), username, authenticate);
		}

		/// <summary>Returns a single custom list. Use <see cref="GetListItemsAsync"/> to get the actual items this list contains.</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <returns>See summary</returns>
		public async Task<TraktList> GetListAsync(string listId, string username = _me, bool authenticate = true) {
			return await SendAsync(new TraktUsersListRequest(Client) {
				Id = listId,
				Username = username,
				Authenticate = authenticate
			});
		}

		/// <summary>Update a custom list by sending 1 or more parameters. If you update the list name, the original slug will still be retained so existing references to this list won't break.</summary>
		/// <param name="name">Name of the list</param>
		/// <param name="description">Description for this list</param>
		/// <param name="privacy">Privacy setting for the list</param>
		/// <param name="displayMembers">Should each item be numbered?</param>
		/// <param name="allowComments">Are comments allowed?</param>
		/// <returns>See summary</returns>
		public async Task<TraktList> UpdateListAsync(string name, string description = "", TraktPrivacyOption privacy = TraktPrivacyOption.Unspecified, bool? displayMembers = null, bool? allowComments = null) {
			return await UpdateListAsync(new TraktListRequestBody {
				Name = name,
				Description = description,
				Privacy = privacy,
				DisplayNumbers = displayMembers,
				AllowComments = allowComments
			});
		}

		/// <summary>Update a custom list by sending 1 or more parameters. If you update the list name, the original slug will still be retained so existing references to this list won't break.</summary>
		/// <param name="list">The list</param>
		/// <returns>See summary</returns>
		public async Task<TraktList> UpdateListAsync(TraktListRequestBody list) {
			return await SendAsync(new TraktUsersListsUpdateRequest(Client) {
				RequestBody = list,
				Username = _me //From Justin Nemeth: You can only create lists for yourself, for now anyway.
			});
		}

		/// <summary>Remove a custom list and all items it contains</summary>
		/// <param name="list">The list</param>
		/// <returns>See summary</returns>
		public async Task DeleteListAsync(TraktList list) {
			await DeleteListAsync(list.Ids.GetBestId());
		}

		/// <summary>Remove a custom list and all items it contains</summary>
		/// <param name="listId">The list ID</param>
		/// <returns>See summary</returns>
		public async Task DeleteListAsync(int listId) {
			await DeleteListAsync(listId.ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>Remove a custom list and all items it contains</summary>
		/// <param name="listId">The list ID</param>
		/// <returns>See summary</returns>
		public async Task DeleteListAsync(string listId) {
			await SendAsync(new TraktUsersListDeleteRequest(Client) { Id = listId, Username = _me }); //From Justin Nemeth: You can only create lists for yourself, for now anyway.
		}

		/// <summary>Votes help determine popular lists. Only one like is allowed per list per user.</summary>
		/// <param name="list">The list</param>
		/// <param name="username">The user's Trakt username</param>
		/// <returns>See summary</returns>
		public async Task LikeListAsync(TraktList list, string username) {
			await LikeListAsync(list.Ids.GetBestId(), username);
		}

		/// <summary>Votes help determine popular lists. Only one like is allowed per list per user.</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="username">The user's Trakt username</param>
		/// <returns>See summary</returns>
		public async Task LikeListAsync(int listId, string username) {
			await LikeListAsync(listId.ToString(CultureInfo.InvariantCulture), username);
		}

		/// <summary>Votes help determine popular lists. Only one like is allowed per list per user.</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="username">The user's Trakt username</param>
		/// <returns>See summary</returns>
		public async Task LikeListAsync(string listId, string username) {
			await SendAsync(new TraktUsersListLikeRequest(Client) { Id = listId, Username = username });
		}

		/// <summary>Remove a like on a list</summary>
		/// <param name="list">The list</param>
		/// <param name="username">The user's Trakt username</param>
		/// <returns>See summary</returns>
		public async Task UnlikeListAsync(TraktList list, string username) {
			await UnlikeListAsync(list.Ids.GetBestId(), username);
		}

		/// <summary>Remove a like on a list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="username">The user's Trakt username</param>
		/// <returns>See summary</returns>
		public async Task UnlikeListAsync(int listId, string username) {
			await UnlikeListAsync(listId.ToString(CultureInfo.InvariantCulture), username);
		}

		/// <summary>Remove a like on a list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="username">The user's Trakt username</param>
		/// <returns>See summary</returns>
		public async Task UnlikeListAsync(string listId, string username) {
			await SendAsync(new TraktUsersListLikeDeleteRequest(Client) { Id = listId, Username = username });
		}

		/// <summary>Get all items on a custom list. Items can be movies, shows, seasons, episodes, or people.</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktListItemsResponseItem>> GetListItemsAsync(string listId, TraktExtendedOption extended = TraktExtendedOption.Unspecified, string username = _me, bool authenticate = true) {
			return await SendAsync(new TraktUsersListItemsRequest(Client) {
				Id = listId,
				Username = username,
				Extended = extended
			});
		}

		/// <summary>Follow a user</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktUsersFollowResponse> FollowAsync(string username, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersFollowRequest(Client) { Username = username, Extended = extended });
		}

		/// <summary>Unfollow someone you already follow</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <returns>See summary</returns>
		public async Task UnfollowAsync(string username) {
			await SendAsync(new TraktUsersUnfollowRequest(Client) { Username = username });
		}

		/// <summary>Returns all followers including when the relationship began</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUsersFollowResponse>> GetFollowersAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersFollowersRequest(Client) { Username = username, Extended = extended });
		}

		/// <summary>Returns all user's they follow including when the relationship began</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUsersFollowResponse>> GetFollowingAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersFollowingRequest(Client) { Username = username, Extended = extended });
		}

		/// <summary>Returns all friends for a user including when the relationship began. Friendship is a 2 way relationship where each user follows the other.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUsersFriendsResponseItem>> GetFriendsAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersFriendsRequest(Client) { Username = username, Extended = extended });
		}

		/// <summary>Returns movies that a user has watched with the most recent first</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUsersHistoryMoviesResponseItem>> GetMoviesHistoryAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktUsersHistoryMoviesRequest(Client) {
				Username = username,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});
		}

		/// <summary>Returns episodes that a user has watched with the most recent first</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUsersHistoryEpisodesResponseItem>> GetEpisodesHistoryAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktUsersHistoryEpisodesRequest(Client) {
				Username = username,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});
		}

		/// <summary>Get a user's ratings filtered by type. You can optionally filter for a specific rating between 1 and 10.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="rating">The rating</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktRatingsMoviesResponseItem>> GetMovieRatingsAsync(string username = _me, TraktRating rating = TraktRating.Unspecified, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRatingsMoviesRequest(Client) {
				Username = username,
				Rating = rating,
				Extended = extended
			});
		}

		/// <summary>Get a user's ratings filtered by type. You can optionally filter for a specific rating between 1 and 10.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="rating">The rating</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktRatingsShowsResponseItem>> GetShowRatingsAsync(string username = _me, TraktRating rating = TraktRating.Unspecified, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRatingsShowsRequest(Client) {
				Username = username,
				Rating = rating,
				Extended = extended
			});
		}

		/// <summary>Get a user's ratings filtered by type. You can optionally filter for a specific rating between 1 and 10.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="rating">The rating</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktRatingsSeasonsResponseItem>> GetSeasonRatingsAsync(string username = _me, TraktRating rating = TraktRating.Unspecified, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRatingsSeasonsRequest(Client) {
				Username = username,
				Rating = rating,
				Extended = extended
			});
		}

		/// <summary>Get a user's ratings filtered by type. You can optionally filter for a specific rating between 1 and 10.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="rating">The rating</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktRatingsEpisodesResponseItem>> GetEpisodeRatingsAsync(string username = _me, TraktRating rating = TraktRating.Unspecified, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersRatingsEpisodesRequest(Client) {
				Username = username,
				Rating = rating,
				Extended = extended
			});
		}

		/// <summary>Returns all items in a user's watchlist filtered by type. When an item is watched, it will be automatically removed from the watchlist. To track what the user is actively watching, use the progress APIs.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktWatchlistMoviesResponseItem>> GetWatchlistMoviesAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchlistMoviesRequest(Client) { Username = username, Extended = extended });
		}

		/// <summary>Returns all items in a user's watchlist filtered by type. When an item is watched, it will be automatically removed from the watchlist. To track what the user is actively watching, use the progress APIs.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktWatchlistShowsResponseItem>> GetWatchlistShowsAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchlistShowsRequest(Client) { Username = username, Extended = extended });
		}

		/// <summary>Returns all items in a user's watchlist filtered by type. When an item is watched, it will be automatically removed from the watchlist. To track what the user is actively watching, use the progress APIs.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktWatchlistSeasonsResponseItem>> GetWatchlistSeasonsAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchlistSeasonsRequest(Client) { Username = username, Extended = extended });
		}

		/// <summary>Returns all items in a user's watchlist filtered by type. When an item is watched, it will be automatically removed from the watchlist. To track what the user is actively watching, use the progress APIs.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktWatchlistEpisodesResponseItem>> GetWatchlistEpisodesAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchlistEpisodesRequest(Client) { Username = username, Extended = extended });
		}

		/// <summary>Returns a movie or episode if the user is currently watching something. If they are not, it returns no data and a 204 HTTP status code.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktUsersWatchingResponse> GetCurrentlyWatchingAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchingRequest(Client) { Username = username, Extended = extended });
		}

		/// <summary>Returns all movies a user has watched sorted by most plays</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktWatchedMoviesResponseItem>> GetWatchedMoviesAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchedMoviesRequest(Client) { Username = username, Extended = extended });
		}

		/// <summary>Returns all shows a user has watched sorted by most plays</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktWatchedShowsResponseItem>> GetWatchedShowsAsync(string username = _me, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktUsersWatchedShowsRequest(Client) { Username = username, Extended = extended });
		}

		/// <summary>Get a list of recent activity for a user. Activities returned include: checkins, scrobbles, ratings, collections, new lists and comments.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <returns>See summary</returns>
		public async Task<object> GetActivitiesAsync(string username = _me) {
			await Task.Run(() => { throw new NotImplementedException("Feature under development at Trakt"); });
			return null;
		}

		/// <summary>Get a list of recent activity for your friends. Activities returned include: checkins, scrobbles, ratings, collections, new lists and comments.</summary>
		/// <param name="username">The user's Trakt username</param>
		/// <returns>See summary</returns>
		public async Task<object> GetFriendActivitiesAsync(string username = _me) {
			await Task.Run(() => { throw new NotImplementedException("Feature under development at Trakt"); });
			return null;
		}

	}

}
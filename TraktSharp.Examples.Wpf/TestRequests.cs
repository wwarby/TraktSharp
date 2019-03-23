using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Examples.Wpf {

	internal static class TestRequests {

		private static Dictionary<string, Expression> _testRequests = new Dictionary<string, Expression>();

		internal enum TestRequestType {

			// Auth module
			[Description("TraktClient.Auth.LoginAsync()")]
			AuthLoginAsync,
			[Description("TraktClient.Auth.LogoutAsync()")]
			AuthLogoutAsync,

			// Calendars module
			[Description("TraktClient.Calendars.GetShowsAsync()")]
			CalendarsGetShowsAsync,
			[Description("TraktClient.Calendars.GetNewShowsAsync()")]
			CalendarsGetNewShowsAsync,
			[Description("TraktClient.Calendars.GetPremiereShowsAsync()")]
			CalendarsGetPremiereShowsAsync,
			[Description("TraktClient.Calendars.GetMoviesAsync()")]
			CalendarsGetMoviesAsync,

			// Checkin module
			[Description("TraktClient.Checkin.CheckinMovieAsync()")]
			CheckinCheckinMovieAsync,
			[Description("TraktClient.Checkin.CheckinEpisodeAsync()")]
			CheckinCheckinEpisodeAsync,
			[Description("TraktClient.Checkin.RemoveActiveCheckinAsync()")]
			CheckinRemoveActiveCheckinAsync,

			// Comments module
			[Description("TraktClient.Comments.PostMovieCommentAsync()")]
			CommentsPostMovieCommentAsync,
			[Description("TraktClient.Comments.PostShowCommentAsync()")]
			CommentsPostShowCommentAsync,
			[Description("TraktClient.Comments.PostEpisodeCommentAsync()")]
			CommentsPostEpisodeCommentAsync,
			[Description("TraktClient.Comments.PostListCommentAsync()")]
			CommentsPostListCommentAsync,
			[Description("TraktClient.Comments.GetCommentAsync()")]
			CommentsGetCommentAsync,
			[Description("TraktClient.Comments.UpdateCommentAsync()")]
			CommentsUpdateCommentAsync,
			[Description("TraktClient.Comments.DeleteCommentAsync()")]
			CommentsDeleteCommentAsync,
			[Description("TraktClient.Comments.LikeCommentAsync()")]
			CommentsLikeCommentAsync,
			[Description("TraktClient.Comments.UnlikeCommentAsync()")]
			CommentsUnlikeCommentAsync,

			// Episodes module
			[Description("TraktClient.Episodes.GetEpisodeAsync()")]
			EpisodesGetEpisodeAsync,
			[Description("TraktClient.Episodes.GetCommentsAsync()")]
			EpisodesGetCommentsAsync,
			[Description("TraktClient.Episodes.GetRatingsAsync()")]
			EpisodesGetRatingsAsync,
			[Description("TraktClient.Episodes.GetStatsAsync()")]
			EpisodesGetStatsAsync,
			[Description("TraktClient.Episodes.GetUsersWatchingEpisodeAsync()")]
			EpisodesGetUsersWatchingEpisodeAsync,

			// Genres module
			[Description("TraktClient.Genres.GetGenresAsync(Movies)")]
			GenresGetGenresAsyncMovies,
			[Description("TraktClient.Genres.GetGenresAsync(Shows)")]
			GenresGetGenresAsyncShows,

			// Movies module
			[Description("TraktClient.Movies.GetPopularMoviesAsync()")]
			MoviesGetPopularMoviesAsync,
			[Description("TraktClient.Movies.GetTrendingMoviesAsync()")]
			MoviesGetTrendingMoviesAsync,
			[Description("TraktClient.Movies.GetUpdatedMoviesAsync()")]
			MoviesGetUpdatedMoviesAsync,
			[Description("TraktClient.Movies.GetMovieAsync()")]
			MoviesGetMovieAsync,
			[Description("TraktClient.Movies.GetAliasesAsync()")]
			MoviesGetAliasesAsync,
			[Description("TraktClient.Movies.GetReleasesAsync()")]
			MoviesGetReleasesAsync,
			[Description("TraktClient.Movies.GetTranslationsAsync()")]
			MoviesGetTranslationsAsync,
			[Description("TraktClient.Movies.GetCommentsAsync()")]
			MoviesGetCommentsAsync,
			[Description("TraktClient.Movies.GetCastAndCrewAsync()")]
			MoviesGetCastAndCrewAsync,
			[Description("TraktClient.Movies.GetRatingsAsync()")]
			MoviesGetRatingsAsync,
			[Description("TraktClient.Movies.GetRelatedMoviesAsync()")]
			MoviesGetRelatedMoviesAsync,
			[Description("TraktClient.Movies.GetStatsAsync()")]
			MoviesGetStatsAsync,
			[Description("TraktClient.Movies.GetUsersWatchingMovieAsync()")]
			MoviesGetUsersWatchingMovieAsync,

			// People module
			[Description("TraktClient.People.GetPersonAsync()")]
			PeopleGetPersonAsync,
			[Description("TraktClient.People.GetMoviesForPersonAsync()")]
			PeopleGetMoviesForPersonAsync,
			[Description("TraktClient.People.GetShowsForPersonAsync()")]
			PeopleGetShowsForPersonAsync,

			// Recommendations module
			[Description("TraktClient.Recommendations.GetRecommendedMoviesAsync()")]
			RecommendationsGetRecommendedMoviesAsync,
			[Description("TraktClient.Recommendations.DismissMovieRecommendationAsync()")]
			RecommendationsDismissMovieRecommendationAsync,
			[Description("TraktClient.Recommendations.GetRecommendedShowsAsync()")]
			RecommendationsGetRecommendedShowsAsync,
			[Description("TraktClient.Recommendations.DismissShowRecommendationAsync()")]
			RecommendationsDismissShowRecommendationAsync,

			// Scrobble module
			[Description("TraktClient.Scrobble.StartMovieAsync()")]
			ScrobbleStartMovieAsync,
			[Description("TraktClient.Scrobble.StartEpisodeAsync()")]
			ScrobbleStartEpisodeAsync,
			[Description("TraktClient.Scrobble.PauseMovieAsync()")]
			ScrobblePauseMovieAsync,
			[Description("TraktClient.Scrobble.PauseEpisodeAsync()")]
			ScrobblePauseEpisodeAsync,
			[Description("TraktClient.Scrobble.StopMovieAsync()")]
			ScrobbleStopMovieAsync,
			[Description("TraktClient.Scrobble.StopEpisodeAsync()")]
			ScrobbleStopEpisodeAsync,

			// Seasons module
			[Description("TraktClient.Seasons.GetSeasonOverviewAsync()")]
			SeasonsGetSeasonOverviewAsync,
			[Description("TraktClient.Seasons.SeasonsGetEpisodesForSeasonAsync()")]
			SeasonsGetEpisodesForSeasonAsync,
			[Description("TraktClient.Seasons.GetCommentsAsync()")]
			SeasonsGetCommentsAsync,
			[Description("TraktClient.Seasons.GetRatingsAsync()")]
			SeasonsGetRatingsAsync,
			[Description("TraktClient.Seasons.GetUsersWatchingSeasonAsync()")]
			SeasonsGetUsersWatchingSeasonAsync,

			// Shows module
			[Description("TraktClient.Shows.GetPopularShowsAsync()")]
			ShowsGetPopularShowsAsync,
			[Description("TraktClient.Shows.GetTrendingShowsAsync()")]
			ShowsGetTrendingShowsAsync,
			[Description("TraktClient.Shows.GetUpdatedShowsAsync()")]
			ShowsGetUpdatedShowsAsync,
			[Description("TraktClient.Shows.GetShowAsync()")]
			ShowsGetShowAsync,
			[Description("TraktClient.Shows.GetAliasesAsync()")]
			ShowsGetAliasesAsync,
			[Description("TraktClient.Shows.GetTranslationsAsync()")]
			ShowsGetTranslationsAsync,
			[Description("TraktClient.Shows.GetCommentsAsync()")]
			ShowsGetCommentsAsync,
			[Description("TraktClient.Shows.GetCollectionProgressAsync()")]
			ShowsGetCollectionProgressAsync,
			[Description("TraktClient.Shows.GetWatchedProgressAsync()")]
			ShowsGetWatchedProgressAsync,
			[Description("TraktClient.Shows.GetCastAndCrewAsync()")]
			ShowsGetCastAndCrewAsync,
			[Description("TraktClient.Shows.GetRatingsAsync()")]
			ShowsGetRatingsAsync,
			[Description("TraktClient.Shows.GetRelatedShowsAsync()")]
			ShowsGetRelatedShowsAsync,
			[Description("TraktClient.Shows.GetStatsAsync()")]
			ShowsGetStatsAsync,
			[Description("TraktClient.Shows.GetUsersWatchingShowAsync()")]
			ShowsGetUsersWatchingShowAsync,

			// Sync module

			[Description("TraktClient.Sync.GetLastActivitiesAsync()")]
			SyncGetLastActivitiesAsync,
			[Description("TraktClient.Sync.GetPlaybackStateAsync()")]
			SyncGetPlaybackStateAsync,
			[Description("TraktClient.Sync.GetMoviesCollectionAsync()")]
			SyncGetMoviesCollectionAsync,
			[Description("TraktClient.Sync.GetShowsCollectionAsync()")]
			SyncGetShowsCollectionAsync,

			[Description("TraktClient.Sync.AddToCollectionByMovieIdAsync()")]
			SyncAddToCollectionByMovieIdAsync,
			[Description("TraktClient.Sync.AddToCollectionByShowIdAsync()")]
			SyncAddToCollectionByShowIdAsync,
			[Description("TraktClient.Sync.AddToCollectionByShowIdAsync(SeasonNumbers)")]
			SyncAddToCollectionByShowIdAsyncSeasonNumbers,
			[Description("TraktClient.Sync.AddToCollectionByEpisodeIdAsync()")]
			SyncAddToCollectionByEpisodeIdAsync,

			[Description("TraktClient.Sync.RemoveFromCollectionByMovieIdAsync()")]
			SyncRemoveFromCollectionByMovieIdAsync,
			[Description("TraktClient.Sync.RemoveFromCollectionByShowIdAsync()")]
			SyncRemoveFromCollectionByShowIdAsync,
			[Description("TraktClient.Sync.RemoveFromCollectionByShowIdAsync(SeasonNumbers)")]
			SyncRemoveFromCollectionByShowIdAsyncSeasonNumbers,
			[Description("TraktClient.Sync.RemoveFromCollectionByEpisodeIdAsync()")]
			SyncRemoveFromCollectionByEpisodeIdAsync,

			[Description("TraktClient.Sync.GetWatchedMoviesAsync()")]
			SyncGetWatchedMoviesAsync,
			[Description("TraktClient.Sync.GetWatchedShowsAsync()")]
			SyncGetWatchedShowsAsync,

			[Description("TraktClient.Sync.MarkWatchedByMovieIdAsync()")]
			SyncMarkWatchedByMovieIdAsync,
			[Description("TraktClient.Sync.MarkWatchedByShowIdAsync()")]
			SyncMarkWatchedByShowIdAsync,
			[Description("TraktClient.Sync.MarkWatchedByShowIdAsync(SeasonNumbers)")]
			SyncMarkWatchedByShowIdAsyncSeasonNumbers,
			[Description("TraktClient.Sync.MarkWatchedByEpisodeIdAsync()")]
			SyncMarkWatchedByEpisodeIdAsync,

			[Description("TraktClient.Sync.MarkUnwatchedByMovieIdAsync()")]
			SyncMarkUnwatchedByMovieIdAsync,
			[Description("TraktClient.Sync.MarkUnwatchedByShowIdAsync()")]
			SyncMarkUnwatchedByShowIdAsync,
			[Description("TraktClient.Sync.MarkUnwatchedByShowIdAsync(SeasonNumbers)")]
			SyncMarkUnwatchedByShowIdAsyncSeasonNumbers,
			[Description("TraktClient.Sync.MarkUnwatchedByEpisodeIdAsync()")]
			SyncMarkUnwatchedByEpisodeIdAsync,

			[Description("TraktClient.Sync.GetMovieRatingsAsync()")]
			SyncGetMovieRatingsAsync,
			[Description("TraktClient.Sync.GetShowRatingsAsync()")]
			SyncGetShowRatingsAsync,
			[Description("TraktClient.Sync.GetSeasonRatingsAsync()")]
			SyncGetSeasonRatingsAsync,
			[Description("TraktClient.Sync.GetEpisodeRatingsAsync()")]
			SyncGetEpisodeRatingsAsync,

			[Description("TraktClient.Sync.AddRatingByMovieIdAsync()")]
			SyncAddRatingByMovieIdAsync,
			[Description("TraktClient.Sync.AddRatingByShowIdAsync()")]
			SyncAddRatingByShowIdAsync,
			[Description("TraktClient.Sync.AddRatingByShowIdAsync(SeasonNumbers)")]
			SyncAddRatingByShowIdAsyncSeasonNumbers,
			[Description("TraktClient.Sync.AddRatingByEpisodeIdAsync()")]
			SyncAddRatingByEpisodeIdAsync,

			[Description("TraktClient.Sync.RemoveRatingByMovieIdAsync()")]
			SyncRemoveRatingByMovieIdAsync,
			[Description("TraktClient.Sync.RemoveRatingByShowIdAsync()")]
			SyncRemoveRatingByShowIdAsync,
			[Description("TraktClient.Sync.RemoveRatingByShowIdAsync(SeasonNumbers)")]
			SyncRemoveRatingByShowIdAsyncSeasonNumbers,
			[Description("TraktClient.Sync.RemoveRatingByEpisodeIdAsync()")]
			SyncRemoveRatingByEpisodeIdAsync,

			[Description("TraktClient.Sync.GetWatchlistMoviesAsync()")]
			SyncGetWatchlistMoviesAsync,
			[Description("TraktClient.Sync.GetWatchlistShowsAsync()")]
			SyncGetWatchlistShowsAsync,
			[Description("TraktClient.Sync.GetWatchlistSeasonsAsync()")]
			SyncGetWatchlistSeasonsAsync,
			[Description("TraktClient.Sync.GetWatchlistEpisodesAsync()")]
			SyncGetWatchlistEpisodesAsync,

			[Description("TraktClient.Sync.AddToWatchlistByMovieIdAsync()")]
			SyncAddToWatchlistByMovieIdAsync,
			[Description("TraktClient.Sync.AddToWatchlistByShowIdAsync()")]
			SyncAddToWatchlistByShowIdAsync,
			[Description("TraktClient.Sync.AddToWatchlistByShowIdAsync(SeasonNumbers)")]
			SyncAddToWatchlistByShowIdAsyncSeasonNumbers,
			[Description("TraktClient.Sync.AddToWatchlistByEpisodeIdAsync()")]
			SyncAddToWatchlistByEpisodeIdAsync,

			[Description("TraktClient.Sync.RemoveFromWatchlistByMovieIdAsync()")]
			SyncRemoveFromWatchlistByMovieIdAsync,
			[Description("TraktClient.Sync.RemoveFromWatchlistByShowIdAsync()")]
			SyncRemoveFromWatchlistByShowIdAsync,
			[Description("TraktClient.Sync.RemoveFromWatchlistByShowIdAsync(SeasonNumbers)")]
			SyncRemoveFromWatchlistByShowIdAsyncSeasonNumbers,
			[Description("TraktClient.Sync.RemoveFromWatchlistByEpisodeIdAsync()")]
			SyncRemoveFromWatchlistByEpisodeIdAsync,

			// Users module

			[Description("TraktClient.Users.GetSettingsAsync()")]
			UsersGetSettingsAsync,
			[Description("TraktClient.Users.UpdateSettingsAsync()")]
			UsersUpdateSettingsAsync,
			[Description("TraktClient.Users.GetFollowRequestsAsync()")]
			UsersGetFollowRequestsAsync,
			[Description("TraktClient.Users.ApproveFollowRequestAsync()")]
			UsersApproveFollowRequestAsync,
			[Description("TraktClient.Users.DenyFollowRequestAsync()")]
			UsersDenyFollowRequestAsync,
			
			[Description("TraktClient.Users.GetUserAsync()")]
			UsersGetUserAsync,
			[Description("TraktClient.Users.GetMoviesCollectionAsync()")]
			UsersGetMoviesCollectionAsync,
			[Description("TraktClient.Users.GetShowsCollectionAsync()")]
			UsersGetShowsCollectionAsync,

			[Description("TraktClient.Users.GetListsAsync()")]
			UsersGetListsAsync,
			[Description("TraktClient.Users.CreateListAsync()")]
			UsersCreateListAsync,
			[Description("TraktClient.Users.GetListAsync()")]
			UsersGetListAsync,
			
			[Description("TraktClient.Users.AddToListByMovieIdAsync()")]
			UsersAddToListByMovieIdAsync,
			[Description("TraktClient.Users.AddToListByShowIdAsync()")]
			UsersAddToListByShowIdAsync,
			[Description("TraktClient.Users.AddToListByEpisodeIdAsync()")]
			UsersAddToListByEpisodeIdAsync,

			[Description("TraktClient.Users.RemoveFromListByMovieIdAsync()")]
			UsersRemoveFromListByMovieIdAsync,
			[Description("TraktClient.Users.RemoveFromListByShowIdAsync()")]
			UsersRemoveFromListByShowIdAsync,
			[Description("TraktClient.Users.RemoveFromListByEpisodeIdAsync()")]
			UsersRemoveFromListByEpisodeIdAsync,

			[Description("TraktClient.Users.UpdateListAsync()")]
			UsersUpdateListAsync,
			[Description("TraktClient.Users.DeleteListAsync()")]
			UsersDeleteListAsync,
			
			[Description("TraktClient.Users.LikeListAsync()")]
			UsersLikeListAsync,
			[Description("TraktClient.Users.UnlikeListAsync()")]
			UsersUnlikeListAsync,
			[Description("TraktClient.Users.GetListItemsAsync()")]
			UsersGetListItemsAsync,

			[Description("TraktClient.Users.FollowAsync()")]
			UsersFollowAsync,
			[Description("TraktClient.Users.UnfollowAsync()")]
			UsersUnfollowAsync,
			[Description("TraktClient.Users.GetFollowersAsync()")]
			UsersGetFollowersAsync,
			[Description("TraktClient.Users.GetFollowingAsync()")]
			UsersGetFollowingAsync,
			[Description("TraktClient.Users.GetFriendsAsync()")]
			UsersGetFriendsAsync,

			[Description("TraktClient.Users.GetMoviesHistoryAsync()")]
			UsersGetMoviesHistoryAsync,
			[Description("TraktClient.Users.GetEpisodesHistoryAsync()")]
			UsersGetEpisodesHistoryAsync,

			[Description("TraktClient.Users.GetMovieRatingsAsync()")]
			UsersGetMovieRatingsAsync,
			[Description("TraktClient.Users.GetShowRatingsAsync()")]
			UsersGetShowRatingsAsync,
			[Description("TraktClient.Users.GetSeasonRatingsAsync()")]
			UsersGetSeasonRatingsAsync,
			[Description("TraktClient.Users.GetEpisodeRatingsAsync()")]
			UsersGetEpisodeRatingsAsync,

			[Description("TraktClient.Users.GetWatchlistMoviesAsync()")]
			UsersGetWatchlistMoviesAsync,
			[Description("TraktClient.Users.GetWatchlistShowsAsync()")]
			UsersGetWatchlistShowsAsync,
			[Description("TraktClient.Users.GetWatchlistSeasonsAsync()")]
			UsersGetWatchlistSeasonsAsync,
			[Description("TraktClient.Users.GetWatchlistEpisodesAsync()")]
			UsersGetWatchlistEpisodesAsync,

			[Description("TraktClient.Users.GetCurrentlyWatchingAsync()")]
			UsersGetCurrentlyWatchingAsync,
			[Description("TraktClient.Users.GetWatchedMoviesAsync()")]
			UsersGetWatchedMoviesAsync,
			[Description("TraktClient.Users.GetWatchedShowsAsync()")]
			UsersGetWatchedShowsAsync,

			[Description("TraktClient.Users.GetActivitiesAsync()")]
			UsersGetActivitiesAsync,
			[Description("TraktClient.Users.GetFriendActivitiesAsync()")]
			UsersGetFriendActivitiesAsync

		}

		public static async Task<object> ExecuteTestRequest(TraktClient client, TestRequestType requestType, TraktExtendedOption extended = TraktExtendedOption.Unspecified, string testId = null, string testUsername = null, bool authenticateIfOptional = true) {

			//Uncomment if required
			var testIdInt = 0;
			try { if (testId != null) { testIdInt = int.Parse(testId); } } catch {}

			//Default to current user if no test username provided
			if (testUsername == null) { testUsername = client.Authentication.Username ?? string.Empty; }

			switch (requestType) {

				// Auth module
				case TestRequestType.AuthLoginAsync:
					return await client.Auth.LoginAsync("username", "password");
				case TestRequestType.AuthLogoutAsync:
					await client.Auth.LogoutAsync();
					return null;

				// Calendars module
				case TestRequestType.CalendarsGetShowsAsync:
					return await client.Calendars.GetShowsAsync(extended: extended, authenticate: authenticateIfOptional);
				case TestRequestType.CalendarsGetNewShowsAsync:
					return await client.Calendars.GetNewShowsAsync(extended: extended, authenticate: authenticateIfOptional);
				case TestRequestType.CalendarsGetPremiereShowsAsync:
					return await client.Calendars.GetPremiereShowsAsync(extended: extended, authenticate: authenticateIfOptional);
				case TestRequestType.CalendarsGetMoviesAsync:
					return await client.Calendars.GetMoviesAsync(extended: extended, authenticate: authenticateIfOptional);

				// Checkin module
				case TestRequestType.CheckinCheckinMovieAsync:
					return await client.Checkin.CheckinMovieAsync(testId ?? "tt0120591", TraktTextMovieIdType.Auto, extended: extended);
				case TestRequestType.CheckinCheckinEpisodeAsync:
					return await client.Checkin.CheckinEpisodeAsync("Breaking Bad", 2008, 1, 1, extended: extended);
				case TestRequestType.CheckinRemoveActiveCheckinAsync:
					await client.Checkin.RemoveActiveCheckinAsync();
					return null;

				// Comments module
				case TestRequestType.CommentsPostMovieCommentAsync:
					return await client.Comments.PostMovieCommentAsync(testId ?? "tt0120591", TraktTextMovieIdType.Auto, "TraktSharp test comment");
				case TestRequestType.CommentsPostShowCommentAsync:
					return await client.Comments.PostShowCommentAsync(testId ?? "tt0903747", TraktTextShowIdType.Auto, "TraktSharp test comment");
				case TestRequestType.CommentsPostEpisodeCommentAsync:
					return await client.Comments.PostEpisodeCommentAsync(testId ?? "tt0959621", TraktTextEpisodeIdType.Auto, "TraktSharp test comment");
				case TestRequestType.CommentsPostListCommentAsync:
					return await client.Comments.PostListCommentAsync(testId ?? "[list id]", "TraktSharp test comment");
				case TestRequestType.CommentsGetCommentAsync:
					return await client.Comments.GetCommentAsync(testId ?? "[comment id]");
				case TestRequestType.CommentsUpdateCommentAsync:
					return await client.Comments.UpdateCommentAsync(testId ?? "[comment id]", "TraktSharp test comment");
				case TestRequestType.CommentsDeleteCommentAsync:
					await client.Comments.DeleteCommentAsync(testId ?? "[comment id]");
					return null;
				case TestRequestType.CommentsLikeCommentAsync:
					return await client.Comments.LikeCommentAsync(testId ?? "[comment id]");
				case TestRequestType.CommentsUnlikeCommentAsync:
					await client.Comments.UnlikeCommentAsync(testId ?? "[comment id]");
					return null;

				// Episodes module
				case TestRequestType.EpisodesGetEpisodeAsync:
					return await client.Episodes.GetEpisodeAsync(testId ?? "breaking-bad", 1, 1, extended);
				case TestRequestType.EpisodesGetCommentsAsync:
					return await client.Episodes.GetCommentsAsync(testId ?? "breaking-bad", 1, 1);
				case TestRequestType.EpisodesGetRatingsAsync:
					return await client.Episodes.GetRatingsAsync(testId ?? "breaking-bad", 1, 1);
				case TestRequestType.EpisodesGetStatsAsync:
					return await client.Episodes.GetStatsAsync(testId ?? "breaking-bad", 1, 1);
				case TestRequestType.EpisodesGetUsersWatchingEpisodeAsync:
					return await client.Episodes.GetUsersWatchingEpisodeAsync(testId ?? "breaking-bad", 1, 1, extended);

				// Genres module
				case TestRequestType.GenresGetGenresAsyncMovies:
					return await client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies);
				case TestRequestType.GenresGetGenresAsyncShows:
					return await client.Genres.GetGenresAsync(TraktGenreTypeOptions.Shows);

				// Movies module
				case TestRequestType.MoviesGetPopularMoviesAsync:
					return await client.Movies.GetPopularMoviesAsync(extended);
				case TestRequestType.MoviesGetTrendingMoviesAsync:
					return await client.Movies.GetTrendingMoviesAsync(extended);
				case TestRequestType.MoviesGetUpdatedMoviesAsync:
					return await client.Movies.GetUpdatedMoviesAsync(DateTime.Now.AddMonths(-1), extended);
				case TestRequestType.MoviesGetMovieAsync:
					return await client.Movies.GetMovieAsync(testId ?? "tt0120591", extended);
				case TestRequestType.MoviesGetAliasesAsync:
					return await client.Movies.GetAliasesAsync(testId ?? "tt0120591");
				case TestRequestType.MoviesGetReleasesAsync:
					return await client.Movies.GetReleasesAsync(testId ?? "tt0120591", "us");
				case TestRequestType.MoviesGetTranslationsAsync:
					return await client.Movies.GetTranslationsAsync(testId ?? "tt0120591", "es");
				case TestRequestType.MoviesGetCommentsAsync:
					return await client.Movies.GetCommentsAsync(testId ?? "tt0468569");
				case TestRequestType.MoviesGetCastAndCrewAsync:
					return await client.Movies.GetCastAndCrewAsync(testId ?? "tt0120591", extended);
				case TestRequestType.MoviesGetRatingsAsync:
					return await client.Movies.GetRatingsAsync(testId ?? "tt0120591");
				case TestRequestType.MoviesGetRelatedMoviesAsync:
					return await client.Movies.GetRelatedMoviesAsync(testId ?? "tt0120591", extended);
				case TestRequestType.MoviesGetStatsAsync:
					return await client.Movies.GetStatsAsync(testId ?? "tt0120591");
				case TestRequestType.MoviesGetUsersWatchingMovieAsync:
					return await client.Movies.GetUsersWatchingMovieAsync(testId ?? "tt0120591", extended);

				// People module
				case TestRequestType.PeopleGetPersonAsync:
					return await client.People.GetPersonAsync(testId ?? "nm0186505", extended);
				case TestRequestType.PeopleGetMoviesForPersonAsync:
					return await client.People.GetMoviesForPersonAsync(testId ?? "brad-pitt", extended);
				case TestRequestType.PeopleGetShowsForPersonAsync:
					return await client.People.GetShowsForPersonAsync(testId ?? "nm0186505", extended);

				// Recommendations module
				case TestRequestType.RecommendationsGetRecommendedMoviesAsync:
					return await client.Recommendations.GetRecommendedMoviesAsync(extended);
				case TestRequestType.RecommendationsDismissMovieRecommendationAsync:
					await client.Recommendations.DismissMovieRecommendationAsync(testId ?? "tt0942385");
					return null;
				case TestRequestType.RecommendationsGetRecommendedShowsAsync:
					return await client.Recommendations.GetRecommendedShowsAsync(extended);
				case TestRequestType.RecommendationsDismissShowRecommendationAsync:
					await client.Recommendations.DismissShowRecommendationAsync(testId ?? "tt2322158");
					return null;

				// Scrobble module
				case TestRequestType.ScrobbleStartMovieAsync:
					return await client.Scrobble.StartMovieAsync(testId ?? "tt0120591", TraktTextMovieIdType.Auto, 1, extended: extended);
				case TestRequestType.ScrobbleStartEpisodeAsync:
					return await client.Scrobble.StartEpisodeAsync(testId ?? "tt0959621", TraktTextEpisodeIdType.Auto, 1, extended: extended);
				case TestRequestType.ScrobblePauseMovieAsync:
					return await client.Scrobble.PauseMovieAsync(testId ?? "tt0120591", TraktTextMovieIdType.Auto, 50, extended: extended);
				case TestRequestType.ScrobblePauseEpisodeAsync:
					return await client.Scrobble.PauseEpisodeAsync(testId ?? "tt0959621", TraktTextEpisodeIdType.Auto, 50, extended: extended);
				case TestRequestType.ScrobbleStopMovieAsync:
					return await client.Scrobble.StopMovieAsync(testId ?? "tt0120591", TraktTextMovieIdType.Auto, 99.9F, extended: extended);
				case TestRequestType.ScrobbleStopEpisodeAsync:
					return await client.Scrobble.StopEpisodeAsync(testId ?? "tt0959621", TraktTextEpisodeIdType.Auto, 99.9F, extended: extended);

				// Seasons module
				case TestRequestType.SeasonsGetSeasonOverviewAsync:
					return await client.Seasons.GetSeasonOverviewAsync(testId ?? "breaking-bad", extended);
				case TestRequestType.SeasonsGetEpisodesForSeasonAsync:
					return await client.Seasons.GetEpisodesForSeasonAsync(testId ?? "breaking-bad", 1, extended);
				case TestRequestType.SeasonsGetCommentsAsync:
					return await client.Seasons.GetCommentsAsync(testId ?? "breaking-bad", 1);
				case TestRequestType.SeasonsGetRatingsAsync:
					return await client.Seasons.GetRatingsAsync(testId ?? "breaking-bad", 1);
				case TestRequestType.SeasonsGetUsersWatchingSeasonAsync:
					return await client.Seasons.GetUsersWatchingSeasonAsync(testId ?? "breaking-bad", 1);

				// Shows module
				case TestRequestType.ShowsGetPopularShowsAsync:
					return await client.Shows.GetPopularShowsAsync(extended);
				case TestRequestType.ShowsGetTrendingShowsAsync:
					return await client.Shows.GetTrendingShowsAsync(extended);
				case TestRequestType.ShowsGetUpdatedShowsAsync:
					return await client.Shows.GetUpdatedShowsAsync(DateTime.Now.AddMonths(-1), extended);
				case TestRequestType.ShowsGetShowAsync:
					return await client.Shows.GetShowAsync(testId ?? "breaking-bad", extended);
				case TestRequestType.ShowsGetAliasesAsync:
					return await client.Shows.GetAliasesAsync(testId ?? "breaking-bad");
				case TestRequestType.ShowsGetTranslationsAsync:
					return await client.Shows.GetTranslationsAsync(testId ?? "breaking-bad", "es");
				case TestRequestType.ShowsGetCommentsAsync:
					return await client.Shows.GetCommentsAsync(testId ?? "breaking-bad");
				case TestRequestType.ShowsGetCollectionProgressAsync:
					return await client.Shows.GetCollectionProgressAsync(testId ?? "breaking-bad", extended);
				case TestRequestType.ShowsGetWatchedProgressAsync:
					return await client.Shows.GetWatchedProgressAsync(testId ?? "breaking-bad", extended);
				case TestRequestType.ShowsGetCastAndCrewAsync:
					return await client.Shows.GetCastAndCrewAsync(testId ?? "breaking-bad", extended);
				case TestRequestType.ShowsGetRatingsAsync:
					return await client.Shows.GetRatingsAsync(testId ?? "breaking-bad");
				case TestRequestType.ShowsGetRelatedShowsAsync:
					return await client.Shows.GetRelatedShowsAsync(testId ?? "breaking-bad", extended);
				case TestRequestType.ShowsGetStatsAsync:
					return await client.Shows.GetStatsAsync(testId ?? "breaking-bad");
				case TestRequestType.ShowsGetUsersWatchingShowAsync:
					return await client.Shows.GetUsersWatchingShowAsync(testId ?? "breaking-bad", extended);

				// Sync module
				case TestRequestType.SyncGetLastActivitiesAsync:
					return await client.Sync.GetLastActivitiesAsync();
				case TestRequestType.SyncGetPlaybackStateAsync:
					return await client.Sync.GetPlaybackStateAsync(extended);
				case TestRequestType.SyncGetMoviesCollectionAsync:
					return await client.Sync.GetMoviesCollectionAsync(extended);
				case TestRequestType.SyncGetShowsCollectionAsync:
					return await client.Sync.GetShowsCollectionAsync(extended);

				case TestRequestType.SyncAddToCollectionByMovieIdAsync:
					return await client.Sync.AddToCollectionByMovieIdAsync(testId ?? "tt0120591");
				case TestRequestType.SyncAddToCollectionByShowIdAsync:
					return await client.Sync.AddToCollectionByShowIdAsync(testId ?? "breaking-bad");
				case TestRequestType.SyncAddToCollectionByShowIdAsyncSeasonNumbers:
					return await client.Sync.AddToCollectionByShowIdAsync(testId ?? "breaking-bad", seasonNumbers: new[] { 1 });
				case TestRequestType.SyncAddToCollectionByEpisodeIdAsync:
					return await client.Sync.AddToCollectionByEpisodeIdAsync(testId ?? "tt0959621");

				case TestRequestType.SyncRemoveFromCollectionByMovieIdAsync:
					return await client.Sync.RemoveFromCollectionByMovieIdAsync(testId ?? "tt0120591");
				case TestRequestType.SyncRemoveFromCollectionByShowIdAsync:
					return await client.Sync.RemoveFromCollectionByShowIdAsync(testId ?? "breaking-bad");
				case TestRequestType.SyncRemoveFromCollectionByShowIdAsyncSeasonNumbers:
					return await client.Sync.RemoveFromCollectionByShowIdAsync(testId ?? "breaking-bad", seasonNumbers: new[] { 1 });
				case TestRequestType.SyncRemoveFromCollectionByEpisodeIdAsync:
					return await client.Sync.RemoveFromCollectionByEpisodeIdAsync(testId ?? "tt0959621");

				case TestRequestType.SyncGetWatchedMoviesAsync:
					return await client.Sync.GetWatchedMoviesAsync(extended);
				case TestRequestType.SyncGetWatchedShowsAsync:
					return await client.Sync.GetWatchedShowsAsync(extended);

				case TestRequestType.SyncMarkWatchedByMovieIdAsync:
					return await client.Sync.MarkWatchedByMovieIdAsync(testId ?? "tt0120591");
				case TestRequestType.SyncMarkWatchedByShowIdAsync:
					return await client.Sync.MarkWatchedByShowIdAsync(testId ?? "breaking-bad");
				case TestRequestType.SyncMarkWatchedByShowIdAsyncSeasonNumbers:
					return await client.Sync.MarkWatchedByShowIdAsync(testId ?? "breaking-bad", seasonNumbers: new[] { 1 });
				case TestRequestType.SyncMarkWatchedByEpisodeIdAsync:
					return await client.Sync.MarkWatchedByEpisodeIdAsync(testId ?? "tt0959621");

				case TestRequestType.SyncMarkUnwatchedByMovieIdAsync:
					return await client.Sync.MarkUnwatchedByMovieIdAsync(testId ?? "tt0120591");
				case TestRequestType.SyncMarkUnwatchedByShowIdAsync:
					return await client.Sync.MarkUnwatchedByShowIdAsync(testId ?? "breaking-bad");
				case TestRequestType.SyncMarkUnwatchedByShowIdAsyncSeasonNumbers:
					return await client.Sync.MarkUnwatchedByShowIdAsync(testId ?? "breaking-bad", seasonNumbers: new[] { 1 });
				case TestRequestType.SyncMarkUnwatchedByEpisodeIdAsync:
					return await client.Sync.MarkUnwatchedByEpisodeIdAsync(testId ?? "tt0959621");

				case TestRequestType.SyncGetMovieRatingsAsync:
					return await client.Sync.GetMovieRatingsAsync(TraktRating.Unspecified, extended);
				case TestRequestType.SyncGetShowRatingsAsync:
					return await client.Sync.GetShowRatingsAsync(TraktRating.Unspecified, extended);
				case TestRequestType.SyncGetSeasonRatingsAsync:
					return await client.Sync.GetSeasonRatingsAsync(TraktRating.Unspecified, extended);
				case TestRequestType.SyncGetEpisodeRatingsAsync:
					return await client.Sync.GetEpisodeRatingsAsync(TraktRating.Unspecified, extended);

				case TestRequestType.SyncAddRatingByMovieIdAsync:
					return await client.Sync.AddRatingByMovieIdAsync(testId ?? "tt0120591", TraktTextMovieIdType.Auto, TraktRating.Rating7);
				case TestRequestType.SyncAddRatingByShowIdAsync:
					return await client.Sync.AddRatingByShowIdAsync(testId ?? "breaking-bad", TraktTextShowIdType.Auto, TraktRating.Rating7);
				case TestRequestType.SyncAddRatingByShowIdAsyncSeasonNumbers:
					return await client.Sync.AddRatingByShowIdAsync(testId ?? "breaking-bad", TraktTextShowIdType.Auto, TraktRating.Rating7, seasonNumbers: new[] { 1 });
				case TestRequestType.SyncAddRatingByEpisodeIdAsync:
					return await client.Sync.AddRatingByEpisodeIdAsync(testId ?? "tt0959621", TraktTextEpisodeIdType.Auto, TraktRating.Rating7);

				case TestRequestType.SyncRemoveRatingByMovieIdAsync:
					return await client.Sync.RemoveRatingByMovieIdAsync(testId ?? "tt0120591");
				case TestRequestType.SyncRemoveRatingByShowIdAsync:
					return await client.Sync.RemoveRatingByShowIdAsync(testId ?? "breaking-bad");
				case TestRequestType.SyncRemoveRatingByShowIdAsyncSeasonNumbers:
					return await client.Sync.RemoveRatingByShowIdAsync(testId ?? "breaking-bad", seasonNumbers: new[] { 1 });
				case TestRequestType.SyncRemoveRatingByEpisodeIdAsync:
					return await client.Sync.RemoveRatingByEpisodeIdAsync(testId ?? "tt0959621");

				case TestRequestType.SyncGetWatchlistMoviesAsync:
					return await client.Sync.GetWatchlistMoviesAsync(extended);
				case TestRequestType.SyncGetWatchlistShowsAsync:
					return await client.Sync.GetWatchlistShowsAsync(extended);
				case TestRequestType.SyncGetWatchlistSeasonsAsync:
					return await client.Sync.GetWatchlistSeasonsAsync(extended);
				case TestRequestType.SyncGetWatchlistEpisodesAsync:
					return await client.Sync.GetWatchlistEpisodesAsync(extended);

				case TestRequestType.SyncAddToWatchlistByMovieIdAsync:
					return await client.Sync.AddToWatchlistByMovieIdAsync(testId ?? "tt0120591");
				case TestRequestType.SyncAddToWatchlistByShowIdAsync:
					return await client.Sync.AddToWatchlistByShowIdAsync(testId ?? "breaking-bad");
				case TestRequestType.SyncAddToWatchlistByShowIdAsyncSeasonNumbers:
					return await client.Sync.AddToWatchlistByShowIdAsync(testId ?? "breaking-bad", seasonNumbers: new[] { 1 });
				case TestRequestType.SyncAddToWatchlistByEpisodeIdAsync:
					return await client.Sync.AddToWatchlistByEpisodeIdAsync(testId ?? "tt0959621");

				case TestRequestType.SyncRemoveFromWatchlistByMovieIdAsync:
					return await client.Sync.RemoveFromWatchlistByMovieIdAsync(testId ?? "tt0120591");
				case TestRequestType.SyncRemoveFromWatchlistByShowIdAsync:
					return await client.Sync.RemoveFromWatchlistByShowIdAsync(testId ?? "breaking-bad");
				case TestRequestType.SyncRemoveFromWatchlistByShowIdAsyncSeasonNumbers:
					return await client.Sync.RemoveFromWatchlistByShowIdAsync(testId ?? "breaking-bad", seasonNumbers: new[] { 1 });
				case TestRequestType.SyncRemoveFromWatchlistByEpisodeIdAsync:
					return await client.Sync.RemoveFromWatchlistByEpisodeIdAsync(testId ?? "tt0959621");

				// Users module
				case TestRequestType.UsersGetSettingsAsync:
					return await client.Users.GetSettingsAsync(extended);
				case TestRequestType.UsersUpdateSettingsAsync:
					return await client.Users.UpdateSettingsAsync();
				case TestRequestType.UsersGetFollowRequestsAsync:
					return await client.Users.GetFollowRequestsAsync(extended);
				case TestRequestType.UsersApproveFollowRequestAsync:
					return await client.Users.ApproveFollowRequestAsync(testIdInt, extended);
				case TestRequestType.UsersDenyFollowRequestAsync:
					await client.Users.DenyFollowRequestAsync(testIdInt);
					return null;
				
				case TestRequestType.UsersGetUserAsync:
					return await client.Users.GetUserAsync(testUsername, extended, authenticateIfOptional);
				case TestRequestType.UsersGetMoviesCollectionAsync:
					return await client.Users.GetMoviesCollectionAsync(testUsername, extended, authenticateIfOptional);
				case TestRequestType.UsersGetShowsCollectionAsync:
					return await client.Users.GetShowsCollectionAsync(testUsername, extended, authenticateIfOptional);
				
				case TestRequestType.UsersGetListsAsync:
					return await client.Users.GetListsAsync(testUsername, authenticateIfOptional);
				case TestRequestType.UsersCreateListAsync:
					return await client.Users.CreateListAsync("Test List", "Test List Description");
				case TestRequestType.UsersGetListAsync:
					return await client.Users.GetListAsync(testId, testUsername, authenticateIfOptional);

				case TestRequestType.UsersUpdateListAsync:
					return await client.Users.UpdateListAsync(testId, "Test List Updated", "Test List Description Updated");
				case TestRequestType.UsersDeleteListAsync:
					await client.Users.DeleteListAsync(testId);
					return null;

				case TestRequestType.UsersAddToListByMovieIdAsync:
					return await client.Users.AddToListByMovieIdAsync(testId, "tt0120591");
				case TestRequestType.UsersAddToListByShowIdAsync:
					return await client.Users.AddToListByShowIdAsync(testId, "breaking-bad");
				case TestRequestType.UsersAddToListByEpisodeIdAsync:
					return await client.Users.AddToListByEpisodeIdAsync(testId, "tt0959621");

				case TestRequestType.UsersRemoveFromListByMovieIdAsync:
					return await client.Users.RemoveFromListByMovieIdAsync(testId, "tt0120591");
				case TestRequestType.UsersRemoveFromListByShowIdAsync:
					return await client.Users.RemoveFromListByShowIdAsync(testId, "breaking-bad");
				case TestRequestType.UsersRemoveFromListByEpisodeIdAsync:
					return await client.Users.RemoveFromListByEpisodeIdAsync(testId, "tt0959621");

				case TestRequestType.UsersLikeListAsync:
					await client.Users.LikeListAsync(testId, testUsername);
					return null;
				case TestRequestType.UsersUnlikeListAsync:
					await client.Users.UnlikeListAsync(testId, testUsername);
					return null;
				case TestRequestType.UsersGetListItemsAsync:
					return await client.Users.GetListItemsAsync(testId, extended, testUsername, authenticateIfOptional);
				
				case TestRequestType.UsersFollowAsync:
					return await client.Users.FollowAsync(testUsername, extended);
				case TestRequestType.UsersUnfollowAsync:
					await client.Users.UnfollowAsync(testUsername);
					return null;
				case TestRequestType.UsersGetFollowersAsync:
					return await client.Users.GetFollowersAsync(testUsername, extended);
				case TestRequestType.UsersGetFollowingAsync:
					return await client.Users.GetFollowingAsync(testUsername, extended);
				case TestRequestType.UsersGetFriendsAsync:
					return await client.Users.GetFriendsAsync(testUsername, extended);

				case TestRequestType.UsersGetMoviesHistoryAsync:
					return await client.Users.GetMoviesHistoryAsync(testUsername, extended);
				case TestRequestType.UsersGetEpisodesHistoryAsync:
					return await client.Users.GetEpisodesHistoryAsync(testUsername, extended);

				case TestRequestType.UsersGetMovieRatingsAsync:
					return await client.Users.GetMovieRatingsAsync(testUsername, extended: extended);
				case TestRequestType.UsersGetShowRatingsAsync:
					return await client.Users.GetShowRatingsAsync(testUsername, extended: extended);
				case TestRequestType.UsersGetSeasonRatingsAsync:
					return await client.Users.GetSeasonRatingsAsync(testUsername, extended: extended);
				case TestRequestType.UsersGetEpisodeRatingsAsync:
					return await client.Users.GetEpisodeRatingsAsync(testUsername, extended: extended);

				case TestRequestType.UsersGetWatchlistMoviesAsync:
					return await client.Users.GetWatchlistMoviesAsync(testUsername, extended);
				case TestRequestType.UsersGetWatchlistShowsAsync:
					return await client.Users.GetWatchlistShowsAsync(testUsername, extended);
				case TestRequestType.UsersGetWatchlistSeasonsAsync:
					return await client.Users.GetWatchlistSeasonsAsync(testUsername, extended);
				case TestRequestType.UsersGetWatchlistEpisodesAsync:
					return await client.Users.GetWatchlistEpisodesAsync(testUsername, extended);

				case TestRequestType.UsersGetCurrentlyWatchingAsync:
					return await client.Users.GetCurrentlyWatchingAsync(testUsername, extended);
				case TestRequestType.UsersGetWatchedMoviesAsync:
					return await client.Users.GetWatchedMoviesAsync(testUsername, extended);
				case TestRequestType.UsersGetWatchedShowsAsync:
					return await client.Users.GetWatchedShowsAsync(testUsername, extended);

				case TestRequestType.UsersGetActivitiesAsync:
					return await client.Users.GetActivitiesAsync(testUsername);
				case TestRequestType.UsersGetFriendActivitiesAsync:
					return await client.Users.GetFriendActivitiesAsync(testUsername);

				// Invalid request type
				default:
					throw new ArgumentOutOfRangeException(nameof(requestType),
						$"A test case has not been implemented for the requested method type: {TraktEnumHelper.GetDescription(requestType)}");
			}

		}

	}

}
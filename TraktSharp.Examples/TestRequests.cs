using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TraktSharp.Helpers;

namespace TraktSharp.Examples {

	public static class TestRequests {

		private static Dictionary<string, Expression> _testRequests = new Dictionary<string, Expression>();

		public enum TestRequestType {
			
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

		}

		public static async Task<object> ExecuteTestRequest(TraktClient client, TestRequestType requestType, ExtendedOption extended = ExtendedOption.Unspecified, string testId = null) {

			switch (requestType) {
				
				// Auth module
				case TestRequestType.AuthLoginAsync:
					return await client.Auth.LoginAsync("username", "password");
				case TestRequestType.AuthLogoutAsync:
					await client.Auth.LogoutAsync();
					return null;
				
				// Calendars module
				case TestRequestType.CalendarsGetShowsAsync:
					return await client.Calendars.GetShowsAsync(extended: extended);
				case TestRequestType.CalendarsGetNewShowsAsync:
					return await client.Calendars.GetNewShowsAsync(extended: extended);
				case TestRequestType.CalendarsGetPremiereShowsAsync:
					return await client.Calendars.GetPremiereShowsAsync(extended: extended);
				case TestRequestType.CalendarsGetMoviesAsync:
					return await client.Calendars.GetMoviesAsync(extended: extended);

				// Checkin module
				case TestRequestType.CheckinCheckinMovieAsync:
					return await client.Checkin.CheckinMovieAsync(testId ?? "tt0120591", StringMovieIdType.Auto, extended: extended);
				case TestRequestType.CheckinCheckinEpisodeAsync:
					return await client.Checkin.CheckinEpisodeAsync("Breaking Bad", 2008, 1, 1, extended: extended);
				case TestRequestType.CheckinRemoveActiveCheckinAsync:
					await client.Checkin.RemoveActiveCheckinAsync();
					return null;

				// Comments module
				case TestRequestType.CommentsPostMovieCommentAsync:
					return await client.Comments.PostMovieCommentAsync(testId ?? "tt0120591", StringMovieIdType.Auto, "TraktSharp test comment");
				case TestRequestType.CommentsPostShowCommentAsync:
					return await client.Comments.PostShowCommentAsync(testId ?? "tt0903747", StringShowIdType.Auto, "TraktSharp test comment");
				case TestRequestType.CommentsPostEpisodeCommentAsync:
					return await client.Comments.PostEpisodeCommentAsync(testId ?? "tt0959621", StringEpisodeIdType.Auto, "TraktSharp test comment");
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
					return await client.Genres.GetGenresAsync(GenreTypeOptions.Movies);
				case TestRequestType.GenresGetGenresAsyncShows:
					return await client.Genres.GetGenresAsync(GenreTypeOptions.Shows);

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
					return await client.Scrobble.StartMovieAsync(testId ?? "tt0120591", StringMovieIdType.Auto, 1, extended: extended);
				case TestRequestType.ScrobbleStartEpisodeAsync:
					return await client.Scrobble.StartEpisodeAsync(testId ?? "tt0959621", StringEpisodeIdType.Auto, 1, extended: extended);
				case TestRequestType.ScrobblePauseMovieAsync:
					return await client.Scrobble.PauseMovieAsync(testId ?? "tt0120591", StringMovieIdType.Auto, 50, extended: extended);
				case TestRequestType.ScrobblePauseEpisodeAsync:
					return await client.Scrobble.PauseEpisodeAsync(testId ?? "tt0959621", StringEpisodeIdType.Auto, 50, extended: extended);
				case TestRequestType.ScrobbleStopMovieAsync:
					return await client.Scrobble.StopMovieAsync(testId ?? "tt0120591", StringMovieIdType.Auto, 99.9F, extended: extended);
				case TestRequestType.ScrobbleStopEpisodeAsync:
					return await client.Scrobble.StopEpisodeAsync(testId ?? "tt0959621", StringEpisodeIdType.Auto, 99.9F, extended: extended);

				// Invalid request type
				default:
					throw new ArgumentOutOfRangeException("requestType",
						string.Format("A test case has not been implemented for the requested method type: {0}", EnumsHelper.GetDescription(requestType)));
			}

		}

	}

}
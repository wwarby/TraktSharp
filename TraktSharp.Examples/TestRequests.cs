using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TraktSharp.Examples.Helpers;
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
			[Description("TraktClient.Episodes.GetEpisodeAsync(Full)")]
			EpisodesGetEpisodeAsyncFull,
			[Description("TraktClient.Episodes.GetEpisodeAsync(Images)")]
			EpisodesGetEpisodeAsyncImages,
			[Description("TraktClient.Episodes.GetEpisodeAsync(FullAndImages)")]
			EpisodesGetEpisodeAsyncFullAndImages,
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
			[Description("TraktClient.Movies.GetMovieAsync(Full)")]
			MoviesGetMovieAsyncFull,
			[Description("TraktClient.Movies.GetMovieAsync(Images)")]
			MoviesGetMovieAsyncImages,
			[Description("TraktClient.Movies.GetMovieAsync(FullAndImages)")]
			MoviesGetMovieAsyncFullAndImages,
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
			[Description("TraktClient.Movies.GetCastAndCrewAsync(Full)")]
			MoviesGetCastAndCrewAsyncFull,
			[Description("TraktClient.Movies.GetCastAndCrewAsync(Images)")]
			MoviesGetCastAndCrewAsyncImages,
			[Description("TraktClient.Movies.GetCastAndCrewAsync(FullAndImages)")]
			MoviesGetCastAndCrewAsyncFullAndImages,
			[Description("TraktClient.Movies.GetRatingsAsync()")]
			MoviesGetRatingsAsync,
			[Description("TraktClient.Movies.GetRelatedMoviesAsync()")]
			MoviesGetRelatedMoviesAsync,
			[Description("TraktClient.Movies.GetStatsAsync()")]
			MoviesGetStatsAsync,
			[Description("TraktClient.Movies.GetUsersWatchingMovieAsync()")]
			MoviesGetUsersWatchingMovieAsync,

		}

		public static async Task<object> ExecuteTestRequest(TraktClient client, TestRequestType requestType) {

			switch (requestType) {
				
				// Auth module
				case TestRequestType.AuthLoginAsync:
					return await client.Auth.LoginAsync("username", "password");
				case TestRequestType.AuthLogoutAsync:
					await client.Auth.LogoutAsync();
					return null;
				
				// Calendars module
				case TestRequestType.CalendarsGetShowsAsync:
					return await client.Calendars.GetShowsAsync();
				case TestRequestType.CalendarsGetNewShowsAsync:
					return await client.Calendars.GetNewShowsAsync();
				case TestRequestType.CalendarsGetPremiereShowsAsync:
					return await client.Calendars.GetPremiereShowsAsync();
				case TestRequestType.CalendarsGetMoviesAsync:
					return await client.Calendars.GetMoviesAsync();

				// Checkin module
				case TestRequestType.CheckinCheckinMovieAsync:
					return await client.Checkin.CheckinMovieAsync("tt0120591", StringMovieIdType.Auto);
				case TestRequestType.CheckinCheckinEpisodeAsync:
					return await client.Checkin.CheckinEpisodeAsync("Breaking Bad", 2008, 1, 1);
				case TestRequestType.CheckinRemoveActiveCheckinAsync:
					await client.Checkin.RemoveActiveCheckinAsync();
					return null;

				// Comments module
				case TestRequestType.CommentsPostMovieCommentAsync:
					return await client.Comments.PostMovieCommentAsync("tt0120591", StringMovieIdType.Auto, "TraktSharp test comment");
				case TestRequestType.CommentsPostShowCommentAsync:
					return await client.Comments.PostShowCommentAsync("tt0903747", StringShowIdType.Auto, "TraktSharp test comment");
				case TestRequestType.CommentsPostEpisodeCommentAsync:
					return await client.Comments.PostEpisodeCommentAsync("tt0959621", StringEpisodeIdType.Auto, "TraktSharp test comment");
				case TestRequestType.CommentsPostListCommentAsync:
					return await client.Comments.PostListCommentAsync("[list id]", "TraktSharp test comment");
				case TestRequestType.CommentsGetCommentAsync:
					return await client.Comments.GetCommentAsync("[comment id]");
				case TestRequestType.CommentsUpdateCommentAsync:
					return await client.Comments.UpdateCommentAsync("[comment id]", "TraktSharp test comment");
				case TestRequestType.CommentsDeleteCommentAsync:
					await client.Comments.DeleteCommentAsync("[comment id]");
					return null;
				case TestRequestType.CommentsLikeCommentAsync:
					return await client.Comments.LikeCommentAsync("[comment id]");
				case TestRequestType.CommentsUnlikeCommentAsync:
					await client.Comments.UnlikeCommentAsync("[comment id]");
					return null;

				// Episodes module
				case TestRequestType.EpisodesGetEpisodeAsync:
					return await client.Episodes.GetEpisodeAsync("breaking-bad", 1, 1);
				case TestRequestType.EpisodesGetEpisodeAsyncFull:
					return await client.Episodes.GetEpisodeAsync("breaking-bad", 1, 1, ExtendedOption.Full);
				case TestRequestType.EpisodesGetEpisodeAsyncImages:
					return await client.Episodes.GetEpisodeAsync("breaking-bad", 1, 1, ExtendedOption.Images);
				case TestRequestType.EpisodesGetEpisodeAsyncFullAndImages:
					return await client.Episodes.GetEpisodeAsync("breaking-bad", 1, 1, ExtendedOption.FullAndImages);
				case TestRequestType.EpisodesGetCommentsAsync:
					return await client.Episodes.GetCommentsAsync("breaking-bad", 1, 1);
				case TestRequestType.EpisodesGetRatingsAsync:
					return await client.Episodes.GetRatingsAsync("breaking-bad", 1, 1);
				case TestRequestType.EpisodesGetStatsAsync:
					return await client.Episodes.GetStatsAsync("breaking-bad", 1, 1);
				case TestRequestType.EpisodesGetUsersWatchingEpisodeAsync:
					return await client.Episodes.GetUsersWatchingEpisodeAsync("breaking-bad", 1, 1);

				// Genres module
				case TestRequestType.GenresGetGenresAsyncMovies:
					return await client.Genres.GetGenresAsync(GenreTypeOptions.Movies);
				case TestRequestType.GenresGetGenresAsyncShows:
					return await client.Genres.GetGenresAsync(GenreTypeOptions.Shows);

				// Movies module
				case TestRequestType.MoviesGetPopularMoviesAsync:
					return await client.Movies.GetPopularMoviesAsync();
				case TestRequestType.MoviesGetTrendingMoviesAsync:
					return await client.Movies.GetTrendingMoviesAsync();
				case TestRequestType.MoviesGetUpdatedMoviesAsync:
					return await client.Movies.GetUpdatedMoviesAsync(DateTime.Now.AddMonths(-1));
				case TestRequestType.MoviesGetMovieAsync:
					return await client.Movies.GetMovieAsync("tt0120591");
				case TestRequestType.MoviesGetMovieAsyncFull:
					return await client.Movies.GetMovieAsync("tt0120591", ExtendedOption.Full);
				case TestRequestType.MoviesGetMovieAsyncImages:
					return await client.Movies.GetMovieAsync("tt0120591", ExtendedOption.Images);
				case TestRequestType.MoviesGetMovieAsyncFullAndImages:
					return await client.Movies.GetMovieAsync("tt0120591", ExtendedOption.FullAndImages);
				case TestRequestType.MoviesGetAliasesAsync:
					return await client.Movies.GetAliasesAsync("tt0120591");
				case TestRequestType.MoviesGetReleasesAsync:
					return await client.Movies.GetReleasesAsync("tt0120591", "us");
				case TestRequestType.MoviesGetTranslationsAsync:
					return await client.Movies.GetTranslationsAsync("tt0120591", "es");
				case TestRequestType.MoviesGetCommentsAsync:
					return await client.Movies.GetCommentsAsync("tt0468569");
				case TestRequestType.MoviesGetCastAndCrewAsync:
					return await client.Movies.GetCastAndCrewAsync("tt0120591");
				case TestRequestType.MoviesGetCastAndCrewAsyncFull:
					return await client.Movies.GetCastAndCrewAsync("tt0120591", ExtendedOption.Full);
				case TestRequestType.MoviesGetCastAndCrewAsyncImages:
					return await client.Movies.GetCastAndCrewAsync("tt0120591", ExtendedOption.Images);
				case TestRequestType.MoviesGetCastAndCrewAsyncFullAndImages:
					return await client.Movies.GetCastAndCrewAsync("tt0120591", ExtendedOption.FullAndImages);
				case TestRequestType.MoviesGetRatingsAsync:
					return await client.Movies.GetRatingsAsync("tt0120591");
				case TestRequestType.MoviesGetRelatedMoviesAsync:
					return await client.Movies.GetRelatedMoviesAsync("tt0120591");
				case TestRequestType.MoviesGetStatsAsync:
					return await client.Movies.GetStatsAsync("tt0120591");
				case TestRequestType.MoviesGetUsersWatchingMovieAsync:
					return await client.Movies.GetUsersWatchingMovieAsync("tt0120591");

				// Invalid request type
				default:
					throw new ArgumentOutOfRangeException("requestType",
						string.Format("A test case has not been implemented for the requested method type: {0}", EnumsHelper.GetDescription(requestType)));
			}

		}

	}

}
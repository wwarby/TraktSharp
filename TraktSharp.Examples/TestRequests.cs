using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Helpers;

namespace TraktSharp.Examples {

	public static class TestRequests {

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

			// Genres module
			[Description("TraktClient.Genres.GetGenresAsync(Movies)")]
			GenresGetGenresAsyncMovies,
			[Description("TraktClient.Genres.GetGenresAsync(Shows)")]
			GenresGetGenresAsyncShows

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

				// Genres module
				case TestRequestType.GenresGetGenresAsyncMovies:
					return await client.Genres.GetGenresAsync(GenreTypeOptions.Movies);
				case TestRequestType.GenresGetGenresAsyncShows:
					return await client.Genres.GetGenresAsync(GenreTypeOptions.Shows);

				// Invalid request type
				default:
					throw new ArgumentOutOfRangeException("requestType",
						string.Format("A test case has not been implemented for the requested method type: {0}", EnumsHelper.GetDescription(requestType)));
			}

		}

	}

}
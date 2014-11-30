using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Factories;
using TraktSharp.Request.Comments;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Comments namespace</summary>
	public class TraktCommentsModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktCommentsModule(TraktClient client) : base(client) { }

		/// <summary>Add a new comment to a movie. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostMovieCommentAsync(string movieId, StringMovieIdType movieIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostMovieCommentAsync(TraktMovieFactory.FromId(movieId, movieIdType), comment, spoiler, review);
		}

		/// <summary>Add a new comment to a movie. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostMovieCommentAsync(int movieId, IntMovieIdType movieIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostMovieCommentAsync(TraktMovieFactory.FromId(movieId, movieIdType), comment, spoiler, review);
		}

		/// <summary>Add a new comment to a movie. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="movieTitle">The movie title</param>
		/// <param name="movieYear">The movie release year</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostMovieCommentAsync(string movieTitle, int? movieYear, string comment, bool? spoiler = null, bool? review = null) {
			return await PostMovieCommentAsync(TraktMovieFactory.FromTitleAndYear(movieTitle, movieYear), comment, spoiler, review);
		}

		/// <summary>Add a new comment to a movie. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="movie">The movie</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostMovieCommentAsync(TraktMovie movie, string comment, bool? spoiler = null, bool? review = null) {
			return await SendAsync(new TraktCommentsPostMovieRequest(Client) {
				RequestBody = new TraktMovieComment {
					Movie = movie,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			});
		}

		/// <summary>Add a new comment to a show. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostShowCommentAsync(string showId, StringShowIdType showIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostShowCommentAsync(TraktShowFactory.FromId(showId, showIdType), comment, spoiler, review);
		}

		/// <summary>Add a new comment to a show. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostShowCommentAsync(int showId, IntShowIdType showIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostShowCommentAsync(TraktShowFactory.FromId(showId, showIdType), comment, spoiler, review);
		}

		/// <summary>Add a new comment to a show. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="showTitle">The show title</param>
		/// <param name="showYear">The show release year (first season)</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostShowCommentAsync(string showTitle, int? showYear, string comment, bool? spoiler = null, bool? review = null) {
			return await PostShowCommentAsync(TraktShowFactory.FromTitleAndYear(showTitle, showYear), comment, spoiler, review);
		}

		/// <summary>Add a new comment to a show. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="show">The show</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostShowCommentAsync(TraktShow show, string comment, bool? spoiler = null, bool? review = null) {
			return await SendAsync(new TraktCommentsPostShowRequest(Client) {
				RequestBody = new TraktShowComment {
					Show = show,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			});
		}

		/// <summary>Add a new comment to an episode. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostEpisodeCommentAsync(string episodeId, StringEpisodeIdType episodeIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostEpisodeCommentAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), comment, spoiler, review);
		}

		/// <summary>Add a new comment to an episode. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostEpisodeCommentAsync(int episodeId, IntEpisodeIdType episodeIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostEpisodeCommentAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), comment, spoiler, review);
		}

		/// <summary>Add a new comment to an episode. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="episode">The episode</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostEpisodeCommentAsync(TraktEpisode episode, string comment, bool? spoiler = null, bool? review = null) {
			return await SendAsync(new TraktCommentsPostEpisodeRequest(Client) {
				RequestBody = new TraktEpisodeComment {
					Episode = episode,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			});
		}

		/// <summary>Add a new comment to a list. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostListCommentAsync(string listId, string comment, bool? spoiler = null, bool? review = null) {
			return await PostListCommentAsync(TraktListFactory.FromId(listId), comment, spoiler, review);
		}

		/// <summary>Add a new comment to a list. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostListCommentAsync(int listId, string comment, bool? spoiler = null, bool? review = null) {
			return await PostListCommentAsync(TraktListFactory.FromId(listId), comment, spoiler, review);
		}

		/// <summary>Add a new comment to a list. If you add a review, it needs to be at least 200 words. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="list">The list</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> PostListCommentAsync(TraktList list, string comment, bool? spoiler = null, bool? review = null) {
			return await SendAsync(new TraktCommentsPostListRequest(Client) {
				RequestBody = new TraktListComment {
					List = list,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			});
		}

		/// <summary>Returns a single comment and indicates how many replies it has, Use <see cref="GetRepliesAsync"/> to get the actual replies</summary>
		/// <param name="comment">The comment</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> GetCommentAsync(TraktComment comment) {
			return await GetCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>Returns a single comment and indicates how many replies it has, Use <see cref="GetRepliesAsync"/> to get the actual replies</summary>
		/// <param name="commentId">The comment ID</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> GetCommentAsync(string commentId) {
			return await SendAsync(new TraktCommentsGetRequest(Client) { Id = commentId });
		}

		/// <summary>Update a single comment created within the last hour. The OAuth user must match the author of the comment in order to update it.</summary>
		/// <param name="comment">The comment</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> UpdateCommentAsync(TraktComment comment) {
			return await UpdateCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture), comment.Comment, comment.Spoiler.GetValueOrDefault(false), comment.Review.GetValueOrDefault(false));
		}

		/// <summary>Update a single comment created within the last hour. The OAuth user must match the author of the comment in order to update it.</summary>
		/// <param name="commentId">The comment ID</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <param name="review">Set to <c>true</c> if the comment is a review</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> UpdateCommentAsync(string commentId, string comment, bool? spoiler = null, bool? review = null) {
			return await SendAsync(new TraktCommentsUpdateRequest(Client) {
				Id = commentId,
				RequestBody = new TraktComment {
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			});
		}

		/// <summary>Delete a single comment created within the last hour. This also effectively removes any replies this comment has. The OAuth user must match the author of the comment in order to delete it.</summary>
		/// <param name="comment">The comment</param>
		/// <returns>See summary</returns>
		public async Task DeleteCommentAsync(TraktComment comment) {
			await DeleteCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>Delete a single comment created within the last hour. This also effectively removes any replies this comment has. The OAuth user must match the author of the comment in order to delete it.</summary>
		/// <param name="commentId">The comment ID</param>
		/// <returns>See summary</returns>
		public async Task DeleteCommentAsync(string commentId) {
			await SendAsync(new TraktCommentsDeleteRequest(Client) { Id = commentId });
		}

		/// <summary>Returns all replies for a comment. It is possible these replies could have replies themselves, so in that case you would just call GET <see cref="GetRepliesAsync"/> again with the new comment id.</summary>
		/// <param name="commentId">The comment ID</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetRepliesAsync(string commentId) {
			return await SendAsync(new TraktCommentsRepliesRequest(Client) { Id = commentId });
		}

		/// <summary>Add a new reply to an existing comment. Also make sure to allow and encourage spoilers to be indicated in your app.</summary>
		/// <param name="commentId">The comment ID</param>
		/// <param name="comment">The comment</param>
		/// <param name="spoiler">Set to <c>true</c> if the comment contains spoilers</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> ReplyToCommentAsync(string commentId, string comment, bool? spoiler = null) {
			return await SendAsync(new TraktCommentsReplyRequest(Client) {
				Id = commentId,
				RequestBody = new TraktComment {
					Comment = comment,
					Spoiler = spoiler
				}
			});
		}

		/// <summary>Votes help determine popular comments. Only one like is allowed per comment per user.</summary>
		/// <param name="comment">The comment</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> LikeCommentAsync(TraktComment comment) {
			return await LikeCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>Votes help determine popular comments. Only one like is allowed per comment per user.</summary>
		/// <param name="commentId">The comment ID</param>
		/// <returns>See summary</returns>
		public async Task<TraktComment> LikeCommentAsync(string commentId) {
			return await SendAsync(new TraktCommentsLikeRequest(Client) { Id = commentId });
		}

		/// <summary>Remove a like on a comment</summary>
		/// <param name="comment">The comment</param>
		/// <returns>See summary</returns>
		public async Task UnlikeCommentAsync(TraktComment comment) {
			await UnlikeCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>Remove a like on a comment</summary>
		/// <param name="commentId">The comment ID</param>
		/// <returns>See summary</returns>
		public async Task UnlikeCommentAsync(string commentId) {
			await SendAsync(new TraktCommentsUnlikeRequest(Client) { Id = commentId });
		}

	}

}
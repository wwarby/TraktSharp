using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Factories;
using TraktSharp.Request.Comments;

namespace TraktSharp.Modules {

	public class TraktCommentsModule : TraktModuleBase {

		public TraktCommentsModule(TraktClient client) : base(client) { }

		public async Task<TraktComment> PostMovieCommentAsync(string movieId, StringMovieIdType movieIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostMovieCommentAsync(TraktMovieFactory.FromId(movieId, movieIdType), comment, spoiler, review);
		}

		public async Task<TraktComment> PostMovieCommentAsync(int movieId, IntMovieIdType movieIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostMovieCommentAsync(TraktMovieFactory.FromId(movieId, movieIdType), comment, spoiler, review);
		}

		public async Task<TraktComment> PostMovieCommentAsync(string movieTitle, int? movieYear, string comment, bool? spoiler = null, bool? review = null) {
			return await PostMovieCommentAsync(TraktMovieFactory.FromTitleAndYear(movieTitle, movieYear), comment, spoiler, review);
		}

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

		public async Task<TraktComment> PostShowCommentAsync(string showId, StringShowIdType showIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostShowCommentAsync(TraktShowFactory.FromId(showId, showIdType), comment, spoiler, review);
		}

		public async Task<TraktComment> PostShowCommentAsync(int showId, IntShowIdType showIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostShowCommentAsync(TraktShowFactory.FromId(showId, showIdType), comment, spoiler, review);
		}

		public async Task<TraktComment> PostShowCommentAsync(string showTitle, int? showYear, string comment, bool? spoiler = null, bool? review = null) {
			return await PostShowCommentAsync(TraktShowFactory.FromTitleAndYear(showTitle, showYear), comment, spoiler, review);
		}

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

		public async Task<TraktComment> PostEpisodeCommentAsync(string episodeId, StringEpisodeIdType episodeIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostEpisodeCommentAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), comment, spoiler, review);
		}

		public async Task<TraktComment> PostEpisodeCommentAsync(int episodeId, IntEpisodeIdType episodeIdType, string comment, bool? spoiler = null, bool? review = null) {
			return await PostEpisodeCommentAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), comment, spoiler, review);
		}

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

		public async Task<TraktComment> PostListCommentAsync(string listId, string comment, bool? spoiler = null, bool? review = null) {
			return await PostListCommentAsync(TraktListFactory.FromId(listId), comment, spoiler, review);
		}

		public async Task<TraktComment> PostListCommentAsync(int listId, string comment, bool? spoiler = null, bool? review = null) {
			return await PostListCommentAsync(TraktListFactory.FromId(listId), comment, spoiler, review);
		}

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

		public async Task<TraktComment> GetCommentAsync(TraktComment comment) {
			return await GetCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		public async Task<TraktComment> GetCommentAsync(string commentId) {
			return await SendAsync(new TraktCommentsGetRequest(Client) { Id = commentId });
		}

		public async Task<TraktComment> UpdateCommentAsync(TraktComment comment) {
			return await UpdateCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture), comment.Comment, comment.Spoiler.GetValueOrDefault(false), comment.Review.GetValueOrDefault(false));
		}

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

		public async Task DeleteCommentAsync(TraktComment comment) {
			await DeleteCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		public async Task DeleteCommentAsync(string commentId) {
			await SendAsync(new TraktCommentsDeleteRequest(Client) { Id = commentId });
		}

		public async Task<IEnumerable<TraktComment>> GetRepliesAsync(string commentId) {
			return await SendAsync(new TraktCommentsRepliesRequest(Client) { Id = commentId });
		}

		public async Task<TraktComment> ReplyToCommentAsync(string commentId, string comment, bool? spoiler = null) {
			return await SendAsync(new TraktCommentsReplyRequest(Client) {
				Id = commentId,
				RequestBody = new TraktComment {
					Comment = comment,
					Spoiler = spoiler
				}
			});
		}

		public async Task<TraktComment> LikeCommentAsync(TraktComment comment) {
			return await LikeCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		public async Task<TraktComment> LikeCommentAsync(string commentId) {
			return await SendAsync(new TraktCommentsLikeRequest(Client) { Id = commentId });
		}

		public async Task UnlikeCommentAsync(TraktComment comment) {
			await UnlikeCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		public async Task UnlikeCommentAsync(string commentId) {
			await SendAsync(new TraktCommentsUnlikeRequest(Client) { Id = commentId });
		}

	}

}
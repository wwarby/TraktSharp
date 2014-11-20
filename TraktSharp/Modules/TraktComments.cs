using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.Comments;

namespace TraktSharp.Modules {

	public class TraktComments {

		public TraktComments(TraktClient client) {
			Client = client;
		}

		public TraktClient Client { get; private set; }

		public async Task<TraktComment> PostAsync(TraktMovie movie, string comment, bool spoiler = false, bool review = false, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCommentsPostMovieRequest(Client) {
				RequestBody = new TraktMovieComment {
					Movie = movie,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				},
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktComment> PostAsync(TraktShow show, string comment, bool spoiler = false, bool review = false, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCommentsPostShowRequest(Client) {
				RequestBody = new TraktShowComment {
					Show = show,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				},
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktComment> PostAsync(TraktEpisode episode, string comment, bool spoiler = false, bool review = false, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCommentsPostEpisodeRequest(Client) {
				RequestBody = new TraktEpisodeComment {
					Episode = episode,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				},
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktComment> PostAsync(TraktList list, string comment, bool spoiler = false, bool review = false, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCommentsPostListRequest(Client) {
				RequestBody = new TraktListComment {
					List = list,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				},
				Extended = extended
			}.SendAsync();
		}

	}

}
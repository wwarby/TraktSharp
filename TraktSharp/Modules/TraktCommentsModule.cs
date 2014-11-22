using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.Checkin;
using TraktSharp.Request.Comments;

namespace TraktSharp.Modules {

	public class TraktCommentsModule {

		public TraktCommentsModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktComment> PostAsync(TraktMovie movie, string comment, bool spoiler = false, bool review = false) {
			return await new TraktCommentsPostMovieRequest(Client) {
				RequestBody = new TraktMovieComment {
					Movie = movie,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			}.SendAsync();
		}

		public async Task<TraktComment> PostAsync(TraktShow show, string comment, bool spoiler = false, bool review = false) {
			return await new TraktCommentsPostShowRequest(Client) {
				RequestBody = new TraktShowComment {
					Show = show,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			}.SendAsync();
		}

		public async Task<TraktComment> PostAsync(TraktEpisode episode, string comment, bool spoiler = false, bool review = false) {
			return await new TraktCommentsPostEpisodeRequest(Client) {
				RequestBody = new TraktEpisodeComment {
					Episode = episode,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			}.SendAsync();
		}

		public async Task<TraktComment> PostAsync(TraktList list, string comment, bool spoiler = false, bool review = false) {
			return await new TraktCommentsPostListRequest(Client) {
				RequestBody = new TraktListComment {
					List = list,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			}.SendAsync();
		}

		public async Task<TraktComment> GetAsync(string id) {
			return await new TraktCommentsGetRequest(Client) {
				Id = id
			}.SendAsync();
		}

		public async Task<TraktComment> UpdateAsync(TraktList list, string comment, bool spoiler = false, bool review = false) {
			return await new TraktCommentsUpdateRequest(Client) {
				RequestBody = new TraktComment {
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			}.SendAsync();
		}

		public async Task DeleteAsync(string id) {
			await new TraktCommentsDeleteRequest(Client) { Id = id }.SendAsync();
		}

	}

}
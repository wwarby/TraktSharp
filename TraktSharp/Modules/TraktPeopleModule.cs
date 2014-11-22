using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.People;

namespace TraktSharp.Modules {

	public class TraktPeopleModule {

		public TraktPeopleModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktPerson> SummaryAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktPeopleSummaryRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktMovieCredits> MoviesAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktPeopleMoviesRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktShowCredits> ShowsAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktPeopleShowsRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

	}

}
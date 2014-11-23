using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.People;

namespace TraktSharp.Modules {

	public class TraktPeopleModule {

		public TraktPeopleModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktPerson> GetPersonAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetPersonAsync(person.Ids.GetBestId(), extended);
		}

		public async Task<TraktPerson> GetPersonAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktPeopleSummaryRequest(Client) {
				Id = personId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktMovieCredits> GetMoviesForPersonAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetMoviesForPersonAsync(person.Ids.GetBestId(), extended);
		}

		public async Task<TraktMovieCredits> GetMoviesForPersonAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktPeopleMoviesRequest(Client) {
				Id = personId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktShowCredits> GetShowsForPersonAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetShowsForPersonAsync(person.Ids.GetBestId(), extended);
		}

		public async Task<TraktShowCredits> GetShowsForPersonAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktPeopleShowsRequest(Client) {
				Id = personId,
				Extended = extended
			}.SendAsync();
		}

	}

}
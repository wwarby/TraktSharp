using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.People;

namespace TraktSharp.Modules {

	public class TraktPeopleModule : TraktModuleBase {

		public TraktPeopleModule(TraktClient client) : base(client) { }

		public async Task<TraktPerson> GetPersonAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetPersonAsync(person.Ids.GetBestId(), extended);
		}

		public async Task<TraktPerson> GetPersonAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktPeopleSummaryRequest(Client) {
				Id = personId,
				Extended = extended
			});
		}

		public async Task<TraktMovieCredits> GetMoviesForPersonAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetMoviesForPersonAsync(person.Ids.GetBestId(), extended);
		}

		public async Task<TraktMovieCredits> GetMoviesForPersonAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktPeopleMoviesRequest(Client) {
				Id = personId,
				Extended = extended
			});
		}

		public async Task<TraktShowCredits> GetShowsForPersonAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetShowsForPersonAsync(person.Ids.GetBestId(), extended);
		}

		public async Task<TraktShowCredits> GetShowsForPersonAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktPeopleShowsRequest(Client) {
				Id = personId,
				Extended = extended
			});
		}

	}

}
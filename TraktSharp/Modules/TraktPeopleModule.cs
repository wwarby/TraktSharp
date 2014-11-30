using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.People;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the People namespace</summary>
	public class TraktPeopleModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktPeopleModule(TraktClient client) : base(client) { }

		/// <summary>Returns a single person's details</summary>
		/// <param name="person">The person</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktPerson> GetPersonAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetPersonAsync(person.Ids.GetBestId(), extended);
		}

		/// <summary>Returns a single person's details</summary>
		/// <param name="personId">The person ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktPerson> GetPersonAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktPeopleSummaryRequest(Client) {
				Id = personId,
				Extended = extended
			});
		}

		/// <summary>Returns all movies where this person is in the cast or crew. Each cast object will have a character and a standard movie object.</summary>
		/// <param name="person">The person</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktMovieCredits> GetMoviesForPersonAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetMoviesForPersonAsync(person.Ids.GetBestId(), extended);
		}

		/// <summary>Returns all movies where this person is in the cast or crew. Each cast object will have a character and a standard movie object.</summary>
		/// <param name="personId">The person ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktMovieCredits> GetMoviesForPersonAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktPeopleMoviesRequest(Client) {
				Id = personId,
				Extended = extended
			});
		}

		/// <summary>Returns all movies where this person is in the cast or crew. Each cast object will have a character and a standard show object.</summary>
		/// <param name="person">The person</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktShowCredits> GetShowsForPersonAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetShowsForPersonAsync(person.Ids.GetBestId(), extended);
		}

		/// <summary>Returns all movies where this person is in the cast or crew. Each cast object will have a character and a standard show object.</summary>
		/// <param name="personId">The person ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktShowCredits> GetShowsForPersonAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktPeopleShowsRequest(Client) {
				Id = personId,
				Extended = extended
			});
		}

	}

}
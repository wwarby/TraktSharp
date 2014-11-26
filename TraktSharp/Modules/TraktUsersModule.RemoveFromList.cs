using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Users;
using TraktSharp.Entities.Response;
using TraktSharp.Factories;
using TraktSharp.Request.Users;

namespace TraktSharp.Modules {

	public partial class TraktUsersModule {

		public async Task<TraktRemoveResponse> RemoveFromListByMovieIdAsync(string listId, string movieId, StringMovieIdType type = StringMovieIdType.Auto) {
			return await RemoveFromListAsync(listId, TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromListByMovieIdAsync(string listId, int movieId, IntMovieIdType type) {
			return await RemoveFromListAsync(listId, TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromListByShowIdAsync(string listId, string showId, StringShowIdType type = StringShowIdType.Auto) {
			return await RemoveFromListAsync(listId, TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromListByShowIdAsync(string listId, int showId, IntShowIdType type) {
			return await RemoveFromListAsync(listId, TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromListByEpisodeIdAsync(string listId, string episodeId, StringEpisodeIdType type = StringEpisodeIdType.Auto) {
			return await RemoveFromListAsync(listId, TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromListByEpisodeIdAsync(string listId, int episodeId, IntEpisodeIdType type) {
			return await RemoveFromListAsync(listId, TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, TraktMovie movie) {
			return await RemoveFromListAsync(listId, new List<TraktMovie> { movie }, null, null, null, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, TraktShow show) {
			return await RemoveFromListAsync(listId, null, new List<TraktShow> { show }, null, null, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, TraktSeason season) {
			return await RemoveFromListAsync(listId, null, null, new List<TraktSeason> { season }, null, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, TraktEpisode episode) {
			return await RemoveFromListAsync(listId, null, null, null, new List<TraktEpisode> { episode }, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, TraktPerson person) {
			return await RemoveFromListAsync(listId, null, null, null, null, new List<TraktPerson> { person });
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, IEnumerable<TraktMovie> movies) {
			return await RemoveFromListAsync(listId, movies, null, null, null, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, IEnumerable<TraktShow> shows) {
			return await RemoveFromListAsync(listId, null, shows, null, null, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, IEnumerable<TraktSeason> seasons) {
			return await RemoveFromListAsync(listId, null, null, seasons, null, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, IEnumerable<TraktEpisode> episodes) {
			return await RemoveFromListAsync(listId, null, null, null, episodes, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, IEnumerable<TraktPerson> people) {
			return await RemoveFromListAsync(listId, null, null, null, null, people);
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds, IEnumerable<string> personIds) {
			return await RemoveFromListAsync(
				listId,
				TraktMovieFactory.FromIds<TraktMovie>(movieIds),
				TraktShowFactory.FromIds<TraktShow>(showIds),
				null, //Seasons only have numeric IDs. For simplicity, exclude them from this overload
				TraktEpisodeFactory.FromIds<TraktEpisode>(episodeIds),
				TraktPersonFactory.FromIds<TraktPerson>(personIds));
		}

		public async Task<TraktRemoveResponse> RemoveFromListAsync(string listId, IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktSeason> seasons, IEnumerable<TraktEpisode> episodes, IEnumerable<TraktPerson> people) {
			return await new TraktUsersListItemsRemoveRequest(Client) {
				RequestBody = new TraktUsersListItemsRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Seasons = seasons,
					Episodes = episodes,
					People = people
				},
				Id = listId,
				Username = _me //From Justin Nemeth: You can only create lists for yourself, for now anyway.
			}.SendAsync();
		}

	}

}
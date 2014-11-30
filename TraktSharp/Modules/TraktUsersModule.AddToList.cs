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

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListByMovieIdAsync(string listId, string movieId, StringMovieIdType movieIdType = StringMovieIdType.Auto) {
			return await AddToListAsync(listId, TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListByMovieIdAsync(string listId, int movieId, IntMovieIdType movieIdType) {
			return await AddToListAsync(listId, TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListByShowIdAsync(string listId, string showId, StringShowIdType showIdType = StringShowIdType.Auto) {
			return await AddToListAsync(listId, TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListByShowIdAsync(string listId, int showId, IntShowIdType showIdType) {
			return await AddToListAsync(listId, TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListByEpisodeIdAsync(string listId, string episodeId, StringEpisodeIdType episodeIdType = StringEpisodeIdType.Auto) {
			return await AddToListAsync(listId, TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListByEpisodeIdAsync(string listId, int episodeId, IntEpisodeIdType episodeIdType) {
			return await AddToListAsync(listId, TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, TraktMovie movie) {
			return await AddToListAsync(listId, new List<TraktMovie> { movie }, null, null, null, null);
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, TraktShow show) {
			return await AddToListAsync(listId, null, new List<TraktShow> { show }, null, null, null);
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="season">The season</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, TraktSeason season) {
			return await AddToListAsync(listId, null, null, new List<TraktSeason> { season }, null, null);
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="episode">The episode</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, TraktEpisode episode) {
			return await AddToListAsync(listId, null, null, null, new List<TraktEpisode> { episode }, null);
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="person">The person</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, TraktPerson person) {
			return await AddToListAsync(listId, null, null, null, null, new List<TraktPerson> { person });
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, IEnumerable<TraktMovie> movies) {
			return await AddToListAsync(listId, movies, null, null, null, null);
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, IEnumerable<TraktShow> shows) {
			return await AddToListAsync(listId, null, shows, null, null, null);
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="seasons">A collection of seasons</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, IEnumerable<TraktSeason> seasons) {
			return await AddToListAsync(listId, null, null, seasons, null, null);
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, IEnumerable<TraktEpisode> episodes) {
			return await AddToListAsync(listId, null, null, null, episodes, null);
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="people">A collection of people</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, IEnumerable<TraktPerson> people) {
			return await AddToListAsync(listId, null, null, null, null, people);
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <param name="personIds">A collection of person IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds, IEnumerable<string> personIds) {
			return await AddToListAsync(
				listId,
				TraktMovieFactory.FromIds<TraktMovie>(movieIds),
				TraktShowFactory.FromIds<TraktShow>(showIds),
				null, //Seasons only have numeric IDs. For simplicity, exclude them from this overload
				TraktEpisodeFactory.FromIds<TraktEpisode>(episodeIds),
				TraktPersonFactory.FromIds<TraktPerson>(personIds));
		}

		/// <summary>Add one or more items to a custom list</summary>
		/// <param name="listId">The list ID</param>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="seasons">A collection of seasons</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <param name="people">A collection of people</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToListAsync(string listId, IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktSeason> seasons, IEnumerable<TraktEpisode> episodes, IEnumerable<TraktPerson> people) {
			return await SendAsync(new TraktUsersListItemsAddRequest(Client) {
				RequestBody = new TraktUsersListItemsAddRequestBody {
					Movies = movies,
					Shows = shows,
					Seasons = seasons,
					Episodes = episodes,
					People = people
				},
				Id = listId,
				Username = _me //From Justin Nemeth: You can only create lists for yourself, for now anyway.
			});
		}

	}

}
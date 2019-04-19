using System.Collections.Generic;
using System.Threading.Tasks;
using TraktSharp.Entities.Response.Genres;
using TraktSharp.Enums;
using TraktSharp.Request.Genres;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Genres namespace</summary>
	public class TraktGenresModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktGenresModule(TraktClient client) : base(client) { }

		/// <summary>Get a list of all genres, including names and slugs</summary>
		/// <param name="genreType">The genre type</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktGenresListResponseItem>> GetGenresAsync(TraktGenreTypeOptions genreType) =>
			await SendAsync(new TraktGenresListRequest(Client) {
				Type = genreType
			});

	}

}
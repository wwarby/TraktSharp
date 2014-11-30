using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.Response.Genres;
using TraktSharp.Request.Genres;

namespace TraktSharp.Modules {

	public class TraktGenresModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktGenresModule(TraktClient client) : base(client) { }

		public async Task<IEnumerable<TraktGenresListResponseItem>> GetGenresAsync(GenreTypeOptions type) {
			return await SendAsync(new TraktGenresListRequest(Client) {
				Type = type
			});
		}

	}

}
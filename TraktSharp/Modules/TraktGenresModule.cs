using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.Response.Genres;
using TraktSharp.Request.Genres;

namespace TraktSharp.Modules {

	public class TraktGenresModule {

		public TraktGenresModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<IEnumerable<TraktGenresListResponseItem>> GetGenresAsync(GenreTypeOptions type) {
			return await new TraktGenresListRequest(Client) {
				Type = type
			}.SendAsync();
		}

	}

}
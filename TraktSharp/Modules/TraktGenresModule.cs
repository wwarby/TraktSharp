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

		public async Task<IEnumerable<TraktGenresListResponseItem>> ListAsync(GenreTypeOptions type, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktGenresListRequest(Client) {
				Type = type,
				Extended = extended
			}.SendAsync();
		}

	}

}
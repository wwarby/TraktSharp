using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Request.Genres;
using TraktSharp.Response.Genres;

namespace TraktSharp.Modules {

	public class TraktGenres {

		public TraktGenres(TraktClient client) {
			Client = client;
		}

		public TraktClient Client { get; private set; }

		public async Task<IEnumerable<TraktGenresListResponseItem>> ListAsync(GenreTypeOptions type, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktGenresListRequest(Client) {
				Type = type,
				Extended = extended
			}.SendAsync();
		}

	}

}
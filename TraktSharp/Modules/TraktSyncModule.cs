using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Request.Sync;

namespace TraktSharp.Modules {

	public class TraktSyncModule {

		public TraktSyncModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktSyncLastActivitiesResponse> LastActivitiesAsync() {
			return await new TraktSyncLastActivitiesRequest(Client).SendAsync();
		}

		public async Task<TraktSyncPlaybackResponse> PlaybackAsync() {
			return await new TraktSyncPlaybackRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncCollectionMoviesResponseItem>> CollectionMoviesAsync() {
			return await new TraktSyncCollectionMoviesRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncCollectionShowsResponseItem>> CollectionShowsAsync() {
			return await new TraktSyncCollectionShowsRequest(Client).SendAsync();
		}

	}

}
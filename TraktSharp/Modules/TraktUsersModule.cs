using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.Users;

namespace TraktSharp.Modules {

	public class TraktUsersModule {

		public TraktUsersModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktUserSettings> GetSettings() {
			return await new TraktUsersSettingsRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktFollowRequest>> GetFollowRequests() {
			return await new TraktUsersRequestsRequest(Client).SendAsync();
		}

	}

}
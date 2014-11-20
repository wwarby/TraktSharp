using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.RequestBody.OAuth;
using TraktSharp.Entities.Response.OAuth;
using TraktSharp.Request.OAuth;

namespace TraktSharp.Modules {

	public class TraktOAuth {

		public TraktOAuth(TraktClient client) {
			Client = client;
		}

		public TraktClient Client { get; private set; }

		public async Task<TraktOAuthTokenResponse> TokenAsync(TraktOAuthTokenRequestBody requestBody) {
			return await new TraktOAuthTokenRequest(Client) { RequestBody = requestBody }.SendAsync();
		}

	}

}
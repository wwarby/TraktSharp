using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Request.OAuth;
using TraktSharp.RequestBody.OAuth;
using TraktSharp.Response.OAuth;

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
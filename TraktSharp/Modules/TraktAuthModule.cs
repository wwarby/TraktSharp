using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.RequestBody.Auth;
using TraktSharp.Entities.Response.Auth;
using TraktSharp.Request.Auth;

namespace TraktSharp.Modules {

	public class TraktAuthModule {

		public TraktAuthModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktAuthLoginResponse> LoginAsync(string login, string password) {
			return await new TraktAuthLoginRequest(Client) {
				RequestBody = new TraktAuthLoginRequestBody {
					Login = login,
					Password = password
				}
			}.SendAsync();
		}

		public async Task LogoutAsync() {
			await new TraktAuthLogoutRequest(Client).SendAsync();
		}

	}

}
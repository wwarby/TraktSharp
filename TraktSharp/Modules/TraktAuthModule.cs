using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.RequestBody.Auth;
using TraktSharp.Entities.Response.Auth;
using TraktSharp.Request.Auth;

namespace TraktSharp.Modules {

	public class TraktAuthModule : TraktModuleBase {

		public TraktAuthModule(TraktClient client) : base(client) { }

		public async Task<TraktAuthLoginResponse> LoginAsync(string login, string password) {
			return await SendAsync(new TraktAuthLoginRequest(Client) {
				RequestBody = new TraktAuthLoginRequestBody {
					Login = login,
					Password = password
				}
			});
		}

		public async Task LogoutAsync() {
			await SendAsync(new TraktAuthLogoutRequest(Client));
		}

	}

}
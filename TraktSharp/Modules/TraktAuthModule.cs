using System.Threading.Tasks;
using TraktSharp.Entities.RequestBody.Auth;
using TraktSharp.Entities.Response.Auth;
using TraktSharp.Request.Auth;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Auth namespace</summary>
	public class TraktAuthModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktAuthModule(TraktClient client) : base(client) { }

		/// <summary>Returns the user's token to be used for authentication.</summary>
		/// <param name="login">Must be set to email or username.</param>
		/// <param name="password">The user's password.</param>
		/// <returns>See summary</returns>
		public async Task<TraktAuthLoginResponse> LoginAsync(string login, string password) =>
			await SendAsync(new TraktAuthLoginRequest(Client) {
				RequestBody = new TraktAuthLoginRequestBody {
					Login = login,
					Password = password
				}
			});

		/// <summary>Resets the user's token. Does not return anything.</summary>
		/// <returns>See summary</returns>
		public async Task LogoutAsync() {
			await SendAsync(new TraktAuthLogoutRequest(Client));
		}

	}

}
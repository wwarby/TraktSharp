using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.RequestBody.Auth;
using TraktSharp.Entities.Response.Auth;
using TraktSharp.Request.Auth;

namespace TraktSharp.Modules {

	/// <summary>
	/// Trakt API authentication methods for media-center applications. See remarks.
	/// </summary>
	/// <remarks>
	/// This is a special case where the application will is allowed to use a simpler token based authenticaion instead of OAuth.
	/// In order to fall under this special use case, you will need to contact the trakt staff and get a special allowance made.
	/// </remarks>
	public class TraktAuthModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktAuthModule(TraktClient client) : base(client) { }

		/// <summary>Returns the user's token to be used for authentication.</summary>
		/// <param name="login">Must be set to email or username.</param>
		/// <param name="password">The user's password.</param>
		/// <returns>See summary</returns>
		public async Task<TraktAuthLoginResponse> LoginAsync(string login, string password) {
			return await SendAsync(new TraktAuthLoginRequest(Client) {
				RequestBody = new TraktAuthLoginRequestBody {
					Login = login,
					Password = password
				}
			});
		}

		/// <summary>Resets the user's token. Does not return anything.</summary>
		/// <returns>See summary</returns>
		public async Task LogoutAsync() {
			await SendAsync(new TraktAuthLogoutRequest(Client));
		}

	}

}
using TraktSharp.Entities;

namespace TraktSharp.Request.Users {

	internal class TraktUsersProfileRequest : TraktGetByUsernameRequest<TraktUser> {

		internal TraktUsersProfileRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}";

	}

}
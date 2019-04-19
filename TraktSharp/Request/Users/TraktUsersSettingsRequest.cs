using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Users {

	internal class TraktUsersSettingsRequest : TraktGetRequest<TraktUserSettings> {

		internal TraktUsersSettingsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/settings";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

	}

}
using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Users {

	internal class TraktUsersSettingsRequest : TraktGetRequest<TraktUserSettings> {

		internal TraktUsersSettingsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/settings"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Required; } }

	}

}
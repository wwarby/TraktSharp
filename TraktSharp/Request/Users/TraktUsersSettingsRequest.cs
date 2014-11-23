using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Users {

	public class TraktUsersSettingsRequest : TraktGetRequest<TraktUserSettings> {

		public TraktUsersSettingsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/settings"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
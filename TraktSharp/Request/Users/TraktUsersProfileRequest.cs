using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Users {

	public class TraktUsersProfileRequest : TraktGetByUsernameRequest<TraktUser> {

		public TraktUsersProfileRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}"; } }

	}

}
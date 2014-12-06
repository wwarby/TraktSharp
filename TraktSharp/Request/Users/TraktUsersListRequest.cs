using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Users {

	internal class TraktUsersListRequest : TraktGetByUsernameAndIdRequest<TraktList> {

		internal TraktUsersListRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists/{id}"; } }

	}

}
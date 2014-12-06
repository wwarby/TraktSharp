using System;
using System.Linq;

namespace TraktSharp.Request.Users {

	internal class TraktUsersListDeleteRequest : TraktDeleteByUsernameAndIdRequest {

		internal TraktUsersListDeleteRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists/{id}"; } }

	}

}
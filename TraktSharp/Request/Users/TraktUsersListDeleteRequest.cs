using System;
using System.Linq;

namespace TraktSharp.Request.Users {

	internal class TraktUsersListDeleteRequest : TraktDeleteByUsernameAndIdRequest {

		internal TraktUsersListDeleteRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/lists/{id}";

	}

}
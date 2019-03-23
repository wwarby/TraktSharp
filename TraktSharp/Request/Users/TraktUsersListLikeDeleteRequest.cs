using System;
using System.Linq;

namespace TraktSharp.Request.Users {

	internal class TraktUsersListLikeDeleteRequest : TraktDeleteByUsernameAndIdRequest {

		internal TraktUsersListLikeDeleteRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/lists/{id}/like";

  }

}
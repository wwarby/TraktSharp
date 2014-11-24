using System;
using System.Linq;

namespace TraktSharp.Request.Users {

	public class TraktUsersListLikeDeleteRequest : TraktDeleteByUsernameAndIdRequest {

		public TraktUsersListLikeDeleteRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists/{id}/like"; } }

	}

}
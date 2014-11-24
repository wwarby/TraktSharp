using System;
using System.Linq;

namespace TraktSharp.Request.Users {

	public class TraktUsersListDeleteRequest : TraktDeleteByUsernameAndIdRequest {

		public TraktUsersListDeleteRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists/{id}"; } }

	}

}
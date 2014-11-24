using System;
using System.Linq;

namespace TraktSharp.Request.Users {

	public class TraktUsersListLikeRequest : TraktBodylessPostByUsernameAndIdRequest<object> {

		public TraktUsersListLikeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists/{id}/like"; } }

	}

}
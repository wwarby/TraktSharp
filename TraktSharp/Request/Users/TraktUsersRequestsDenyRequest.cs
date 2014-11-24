using System;
using System.Linq;

namespace TraktSharp.Request.Users {

	public class TraktUsersRequestsDenyRequest : TraktDeleteByIdRequest {

		public TraktUsersRequestsDenyRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/requests/{id}"; } }

	}

}
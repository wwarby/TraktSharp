using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Users {

	public class TraktUsersListRequest : TraktGetByUsernameAndIdRequest<TraktList> {

		public TraktUsersListRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists/{id}"; } }

	}

}
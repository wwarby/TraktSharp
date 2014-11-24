using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Users {

	public class TraktUsersListsRequest : TraktGetByUsernameRequest<IEnumerable<TraktList>> {

		public TraktUsersListsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists"; } }

	}

}
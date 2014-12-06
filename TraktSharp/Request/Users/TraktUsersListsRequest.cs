using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Users {

	internal class TraktUsersListsRequest : TraktGetByUsernameRequest<IEnumerable<TraktList>> {

		internal TraktUsersListsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists"; } }

	}

}
using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersHistoryMoviesRequest : TraktGetByUsernameRequest<IEnumerable<TraktUsersHistoryMoviesResponseItem>> {

		internal TraktUsersHistoryMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/history/movies"; } }

		protected override bool SupportsPagination { get { return true; } }

	}

}
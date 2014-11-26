using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	public class TraktUsersHistoryMoviesRequest : TraktGetByUsernameRequest<IEnumerable<TraktUsersHistoryMoviesResponseItem>> {

		public TraktUsersHistoryMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/history/movies"; } }

		protected override bool SupportsPagination { get { return true; } }

	}

}
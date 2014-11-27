using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	public class TraktUsersWatchedShowsRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchedShowsResponseItem>> {

		public TraktUsersWatchedShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/watched/shows"; } }

	}

}
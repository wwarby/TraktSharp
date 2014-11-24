using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	public class TraktUsersCollectionShowsRequest : TraktGetByUsernameRequest<IEnumerable<TraktCollectionShowsResponseItem>> {

		public TraktUsersCollectionShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/collection/shows"; } }

	}

}
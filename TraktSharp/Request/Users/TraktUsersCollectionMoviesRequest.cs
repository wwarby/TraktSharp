using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	public class TraktUsersCollectionMoviesRequest : TraktGetByUsernameRequest<IEnumerable<TraktCollectionMoviesResponseItem>> {

		public TraktUsersCollectionMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/collection/movies"; } }

	}

}
using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	public class TraktUsersHistoryEpisodesRequest : TraktGetByUsernameRequest<IEnumerable<TraktUsersHistoryEpisodesResponseItem>> {

		public TraktUsersHistoryEpisodesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/history/episodes"; } }

		protected override bool SupportsPagination { get { return true; } }

	}

}
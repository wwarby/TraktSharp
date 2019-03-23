using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersHistoryEpisodesRequest : TraktGetByUsernameRequest<IEnumerable<TraktUsersHistoryEpisodesResponseItem>> {

		internal TraktUsersHistoryEpisodesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/history/episodes";

    protected override bool SupportsPagination => true;

  }

}
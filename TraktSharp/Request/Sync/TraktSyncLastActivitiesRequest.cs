using System;
using System.Linq;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncLastActivitiesRequest : TraktGetRequest<TraktSyncLastActivitiesResponse> {

		internal TraktSyncLastActivitiesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/last_activities"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Required; } }

	}

}
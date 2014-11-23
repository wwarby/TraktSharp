using System;
using System.Linq;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncLastActivitiesRequest : TraktGetRequest<TraktSyncLastActivitiesResponse> {

		public TraktSyncLastActivitiesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/last_activities"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
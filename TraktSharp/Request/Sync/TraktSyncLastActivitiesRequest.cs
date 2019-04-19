using System;
using System.Linq;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncLastActivitiesRequest : TraktGetRequest<TraktSyncLastActivitiesResponse> {

		internal TraktSyncLastActivitiesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "sync/last_activities";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

	}

}
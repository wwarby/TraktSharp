using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncPlaybackRequest : TraktGetRequest<IEnumerable<TraktSyncPlaybackResponse>> {

		internal TraktSyncPlaybackRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "sync/playback";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

	}

}
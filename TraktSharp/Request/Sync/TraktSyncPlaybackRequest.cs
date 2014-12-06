using System;
using System.Linq;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncPlaybackRequest : TraktGetRequest<TraktSyncPlaybackResponse> {

		internal TraktSyncPlaybackRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/playback"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Required; } }

	}

}
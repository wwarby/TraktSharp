using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncPlaybackRequest : TraktGetRequest<TraktSyncPlaybackResponse> {

		public TraktSyncPlaybackRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/playback"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.Required; } }

	}

}
using System;
using TraktSharp.Entities.RequestBody.Checkin;
using TraktSharp.Entities.Response.Checkin;

namespace TraktSharp.Request.Checkin {

	internal class TraktCheckinEpisodeRequest : TraktPostRequest<TraktCheckinEpisodeResponse, TraktCheckinEpisodeRequestBody> {

		internal TraktCheckinEpisodeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "checkin";

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (RequestBody.Episode == null) {
				throw new ArgumentException("Episode not set");
			}
			if (!RequestBody.Episode.IsPostable(RequestBody.Show)) {
				throw new ArgumentException("Either show title, episode season and episode number or at least one episode id value must be set");
			}
		}

	}

}
using System;
using System.Linq;
using TraktSharp.Entities.RequestBody.Checkin;
using TraktSharp.Entities.Response.Checkin;

namespace TraktSharp.Request.Checkin {

	public class TraktCheckinEpisodeRequest : TraktPostRequest<TraktCheckinEpisodeResponse, TraktCheckinEpisodeRequestBody> {

		public TraktCheckinEpisodeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "checkin"; } }

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
using System;
using System.Linq;
using TraktSharp.Entities.RequestBody.Checkin;
using TraktSharp.Entities.Response.Checkin;

namespace TraktSharp.Request.Checkin {

	[Serializable]
	public class TraktCheckinEpisodeRequest : TraktPostRequest<TraktCheckinEpisodeResponse> {

		public TraktCheckinEpisodeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate {
			get { return "checkin"; }
		}

		protected override void ValidateParameters() {
			var requestBody = RequestBody as TraktCheckinEpisodeRequestBody;
			if (requestBody == null) {
				throw new ArgumentException(string.Format("Request body not set or not an instance of {0}", typeof (TraktCheckinEpisodeRequestBody).Name));
			}
			if (requestBody.Episode == null) {
				throw new ArgumentException("Episode not set");
			}
			if (!requestBody.Episode.IsPostable(requestBody.Show)) {
				throw new ArgumentException("Either show title, episode season and episode number or at least one episode id value must be set");
			}
		}

	}

}
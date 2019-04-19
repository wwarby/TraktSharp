using System;
using System.Linq;
using TraktSharp.Entities.RequestBody.Scrobble;
using TraktSharp.Entities.Response.Scrobble;

namespace TraktSharp.Request.Scrobble {

	internal class TraktScrobbleStopEpisodeRequest : TraktPostRequest<TraktScrobbleEpisodeResponse, TraktScrobbleEpisodeRequestBody> {

		internal TraktScrobbleStopEpisodeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "scrobble/stop";

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (RequestBody.Episode == null) {
				throw new ArgumentException("Episode not set");
			}

			if ((RequestBody.Progress < 0) || (RequestBody.Progress > 100)) {
				throw new ArgumentException("Progress must be between 0 and 100");
			}

			if (!RequestBody.Episode.IsPostable(RequestBody.Show)) {
				throw new ArgumentException("Either show title, episode season and episode number or at least one episode id value must be set");
			}
		}

	}

}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Episodes {

	public class TraktEpisodesWatchingRequest : TraktGetByIdRequest<IEnumerable<TraktUser>> {

		public TraktEpisodesWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/seasons/{season}/episodes/{episode}/watching"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

		public int Season { get; set; }

		public int Episode { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return base.GetPathParameters(pathParameters).Union(new Dictionary<string, string> {
				{"season", Season.ToString(CultureInfo.InvariantCulture)},
				{"episode", Episode.ToString(CultureInfo.InvariantCulture)}
			});
		}

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (Season <= 0) {
				throw new ArgumentException("Season must be a positive integer.");
			}
			if (Episode <= 0) {
				throw new ArgumentException("Episode must be a positive integer.");
			}
		}

	}

}
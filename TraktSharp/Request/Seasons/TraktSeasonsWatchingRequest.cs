using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Seasons {

	public class TraktSeasonsWatchingRequest : TraktGetRequest<IEnumerable<TraktUser>> {

		public TraktSeasonsWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/seasons/{season}/watching"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

		protected override bool SupportsPagination { get { return false; } }

		public string Id { get; set; }

		public int Season { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{ "id", Id },
				{ "season", Season.ToString(CultureInfo.InvariantCulture) }
			};
		}

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Id)) { throw new ArgumentException("Id not set."); }
			if (Season <= 0) { throw new ArgumentException("Season must be a positive integer."); }
		}

	}

}
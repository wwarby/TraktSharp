using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Seasons {

	public class TraktSeasonsCommentsRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

		public TraktSeasonsCommentsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/seasons/{season}/comments"; } }

		protected override bool SupportsPagination { get { return true; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

		public int Season { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return base.GetPathParameters(pathParameters).Union(new Dictionary<string, string> {
				{"season", Season.ToString(CultureInfo.InvariantCulture)}
			});
		}

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (Season <= 0) {
				throw new ArgumentException("Season must be a positive integer.");
			}
		}

	}

}
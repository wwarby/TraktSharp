using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Seasons {

	internal class TraktSeasonsSeasonRequest : TraktGetByIdRequest<IEnumerable<TraktEpisode>> {

		internal TraktSeasonsSeasonRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/{id}/seasons/{season}";

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

    internal int Season { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			base.GetPathParameters(pathParameters).Union(new Dictionary<string, string> {
				{"season", Season.ToString(CultureInfo.InvariantCulture)}
			});

	}

}
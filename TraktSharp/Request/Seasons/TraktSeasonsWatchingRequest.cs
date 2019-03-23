using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Seasons {

	internal class TraktSeasonsWatchingRequest : TraktGetByIdRequest<IEnumerable<TraktUser>> {

		public TraktSeasonsWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/{id}/seasons/{season}/watching";

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

    public int Season { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			base.GetPathParameters(pathParameters).Union(new Dictionary<string, string> {
				{"season", Season.ToString(CultureInfo.InvariantCulture)}
			});

	}

}
﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Episodes {

	internal class TraktEpisodesWatchingRequest : TraktGetByIdRequest<IEnumerable<TraktUser>> {

		internal TraktEpisodesWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/watching";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

    internal int Season { get; set; }

		internal int Episode { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			base.GetPathParameters(pathParameters).Union(new Dictionary<string, string> {
				{"season", Season.ToString(CultureInfo.InvariantCulture)},
				{"episode", Episode.ToString(CultureInfo.InvariantCulture)}
			});

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (Episode <= 0) {
				throw new ArgumentException("Episode must be a positive integer.");
			}
		}

	}

}
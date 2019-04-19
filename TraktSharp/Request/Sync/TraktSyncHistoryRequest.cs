using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncHistoryRequest : TraktGetRequest<IEnumerable<TraktSyncHistoryResponse>> {

		internal TraktSyncHistoryRequest(
			TraktClient client,
			TraktHistoryItemType type = TraktHistoryItemType.Unspecified,
			int? id = null,
			int? page = null,
			int? limit = null,
			DateTimeOffset? from = null,
			DateTimeOffset? to = null
		) : base(client) {
			Id = id;
			Type = type;
			Page = page;
			Limit = limit;
			From = from;
			To = to;

			Template = "sync/history";

			if (type != TraktHistoryItemType.Unspecified) {
				Template += $"/{TraktEnumHelper.GetDescription(type)}";
			}

			if (id != null) {
				Template += $"/{id}";
			}

			var querySet = new Dictionary<string, string>();

			if (from != null) {
				querySet.Add("start_at", from.Value.ToString("yyyy-MM-ddTHH:mm:ssK", CultureInfo.InvariantCulture));
			}

			if (to != null) {
				querySet.Add("end_at", to.Value.ToString("yyyy-MM-ddTHH:mm:ssK", CultureInfo.InvariantCulture));
			}

			if (page != null) {
				querySet.Add("page", page.Value.ToString());
			}

			if (limit != null) {
				querySet.Add("limit", limit.Value.ToString());
			}

			if (querySet.Any()) {
				Template += "?";
				Template += string.Join("&", querySet.Select(query => $"{query.Key}={query.Value}"));
			}
		}

		private string Template { get; }

		protected override string PathTemplate => Template;

		public TraktHistoryItemType Type { get; }

		public int? Id { get; }

		public int? Page { get; }

		public int? Limit { get; }

		public DateTimeOffset? From { get; set; }

		public DateTimeOffset? To { get; set; }

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

	}

}
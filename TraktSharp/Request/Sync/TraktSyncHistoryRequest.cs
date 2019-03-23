using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Enums;

namespace TraktSharp.Request.Sync
{
    internal class TraktSyncHistoryRequest : TraktGetRequest<IEnumerable<TraktSyncHistoryResponse>>
    {
        internal TraktSyncHistoryRequest(TraktClient Client, TraktHistoryItemType Type = TraktHistoryItemType.Unspecified, int? Id = null, int? Page = null, int? Limit = null, DateTimeOffset? From = null, DateTimeOffset? To = null) : base(Client)
        {
            this.Id = Id;
            this.Type = Type;
            this.Page = Page;
            this.Limit = Limit;
            this.From = From;
            this.To = To;

            Template = "sync/history";

            if (Type != TraktHistoryItemType.Unspecified)
            {
                Template += $"/{Helpers.TraktEnumHelper.GetDescription(Type)}";
            }

            if (Id != null)
            {
                Template += $"/{Id}";
            }

            Dictionary<string, string> QuerySet = new Dictionary<string, string>();

            if (From != null)
            {
                QuerySet.Add("start_at", From.Value.ToString("yyyy-MM-ddTHH:mm:ssK", System.Globalization.CultureInfo.InvariantCulture));
            }

            if (To != null)
            {
                QuerySet.Add("end_at", To.Value.ToString("yyyy-MM-ddTHH:mm:ssK", System.Globalization.CultureInfo.InvariantCulture));
            }

            if (Page != null)
            {
                QuerySet.Add("page", Page.Value.ToString());
            }

            if (Limit != null)
            {
                QuerySet.Add("limit", Limit.Value.ToString());
            }

            if (QuerySet.Any())
            {
                Template += "?";
                Template += string.Join("&", QuerySet.Select(query => $"{query.Key}={query.Value}"));
            }
        }

        private string Template { get; set; }
        protected override string PathTemplate { get { return Template; } }

        public TraktHistoryItemType Type { get; }
        public int? Id { get; }
        public int? Page { get; }
        public int? Limit { get; }

        public DateTimeOffset? From { get; set; }
        public DateTimeOffset? To { get; set; }

        protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Required; } }
    }
}
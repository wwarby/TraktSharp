using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Episodes {

    internal class TraktEpisodesCommentsRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

        internal TraktEpisodesCommentsRequest(TraktClient client) : base(client) { }

        public TraktCommentSortOrder Order { get; set; }

        protected override string PathTemplate { get { return "shows/{id}/seasons/{season}/episodes/{episode}/comments/" + TraktEnumHelper.GetDescription(Order); } }

        protected override bool SupportsPagination { get { return true; } }

        protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

        internal int Season { get; set; }

        internal int Episode { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
            return base.GetPathParameters(pathParameters).Union(new Dictionary<string, string> {
                {"season", Season.ToString(CultureInfo.InvariantCulture)},
                {"episode", Episode.ToString(CultureInfo.InvariantCulture)}
            });
        }

        protected override void ValidateParameters() {
            base.ValidateParameters();
            if (Episode <= 0) {
                throw new ArgumentException("Episode must be a positive integer.");
            }
        }
    }
}
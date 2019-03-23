using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Shows {

    internal class TraktShowsCommentsRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

        internal TraktShowsCommentsRequest(TraktClient client) : base(client) { }

        public TraktCommentSortOrder Order { get; set; }

        protected override string PathTemplate { get { return "shows/{id}/comments/" + TraktEnumHelper.GetDescription(Order); } }

        protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

        protected override bool SupportsPagination { get { return true; } }
    }
}
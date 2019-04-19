using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsCommentsRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

		internal TraktShowsCommentsRequest(TraktClient client) : base(client) { }

		public TraktCommentSortOrder Order { get; set; }

		protected override string PathTemplate => "shows/{id}/comments/" + TraktEnumHelper.GetDescription(Order);

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

		protected override bool SupportsPagination => true;

	}

}
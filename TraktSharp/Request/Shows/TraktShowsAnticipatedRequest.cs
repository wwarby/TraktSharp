﻿using System.Collections.Generic;
using TraktSharp.Entities.Response.Shows;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsAnticipatedRequest : TraktGetRequest<IEnumerable<TraktShowsAnticipatedResponseItem>> {

		internal TraktShowsAnticipatedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/anticipated";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

		protected override bool SupportsPagination => true;

	}

}
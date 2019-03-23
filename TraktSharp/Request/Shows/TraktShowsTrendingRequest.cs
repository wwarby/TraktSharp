using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Shows;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsTrendingRequest : TraktGetRequest<IEnumerable<TraktShowsTrendingResponseItem>> {

		internal TraktShowsTrendingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/trending";

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

    protected override bool SupportsPagination => true;

  }

}
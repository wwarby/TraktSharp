using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Recommendations {

	internal class TraktRecommendationsShowsRequest : TraktGetRequest<IEnumerable<TraktShow>> {

		internal TraktRecommendationsShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "recommendations/shows"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Required; } }

	}

}
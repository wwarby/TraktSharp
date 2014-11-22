using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Movies {

	public class TraktRecommendationsShowsRequest : TraktGetRequest<IEnumerable<TraktShow>> {

		public TraktRecommendationsShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "recommendations/shows"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.Required; } }

	}

}
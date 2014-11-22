using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Recommendations {

	public class TraktRecommendationsMoviesRequest : TraktGetRequest<IEnumerable<TraktMovie>> {

		public TraktRecommendationsMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "recommendations/movies"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.Required; } }

	}

}
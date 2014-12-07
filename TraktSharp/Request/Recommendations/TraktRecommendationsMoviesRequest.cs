using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Recommendations {

	internal class TraktRecommendationsMoviesRequest : TraktGetRequest<IEnumerable<TraktMovie>> {

		internal TraktRecommendationsMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "recommendations/movies"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Required; } }

	}

}
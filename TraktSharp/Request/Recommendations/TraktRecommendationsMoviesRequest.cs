using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Recommendations {

	internal class TraktRecommendationsMoviesRequest : TraktGetRequest<IEnumerable<TraktMovie>> {

		internal TraktRecommendationsMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "recommendations/movies";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

	}

}
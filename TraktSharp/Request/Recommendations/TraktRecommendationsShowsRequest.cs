using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Recommendations {

	internal class TraktRecommendationsShowsRequest : TraktGetRequest<IEnumerable<TraktShow>> {

		internal TraktRecommendationsShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "recommendations/shows";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

  }

}
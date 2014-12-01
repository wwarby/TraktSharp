using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Recommendations {

	public class TraktRecommendationsMoviesRequest : TraktGetRequest<IEnumerable<TraktMovie>> {

		public TraktRecommendationsMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "recommendations/movies"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
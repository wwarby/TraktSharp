using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Recommendations {

	public class TraktRecommendationsShowsRequest : TraktGetRequest<IEnumerable<TraktShow>> {

		public TraktRecommendationsShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "recommendations/shows"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}
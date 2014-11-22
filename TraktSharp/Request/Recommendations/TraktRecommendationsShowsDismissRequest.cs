using System;
using System.Linq;

namespace TraktSharp.Request.Recommendations {

	public class TraktRecommendationsShowsDismissRequest : TraktDeleteByIdRequest {

		public TraktRecommendationsShowsDismissRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "recommendations/shows/{id}"; } }

	}

}
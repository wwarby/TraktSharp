using System;
using System.Linq;

namespace TraktSharp.Request.Recommendations {

	internal class TraktRecommendationsMoviesDismissRequest : TraktDeleteByIdRequest {

		internal TraktRecommendationsMoviesDismissRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "recommendations/movies/{id}"; } }

	}

}
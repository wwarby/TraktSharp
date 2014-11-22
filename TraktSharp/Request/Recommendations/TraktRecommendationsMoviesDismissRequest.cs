using System;
using System.Linq;

namespace TraktSharp.Request.Recommendations {

	public class TraktRecommendationsMoviesDismissRequest : TraktDeleteByIdRequest {

		public TraktRecommendationsMoviesDismissRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "recommendations/movies/{id}"; } }

	}

}
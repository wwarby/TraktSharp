namespace TraktSharp.Request.Recommendations {

	internal class TraktRecommendationsShowsDismissRequest : TraktDeleteByIdRequest {

		internal TraktRecommendationsShowsDismissRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "recommendations/shows/{id}";

	}

}
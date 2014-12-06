using System;
using System.Linq;

namespace TraktSharp.Request.Comments {

	internal class TraktCommentsUnlikeRequest : TraktDeleteByIdRequest {

		internal TraktCommentsUnlikeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments/{id}/like"; } }

	}

}
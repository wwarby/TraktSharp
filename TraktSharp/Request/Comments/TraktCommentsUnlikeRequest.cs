using System;
using System.Linq;

namespace TraktSharp.Request.Comments {

	public class TraktCommentsUnlikeRequest : TraktDeleteByIdRequest {

		public TraktCommentsUnlikeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments/{id}/like"; } }

	}

}
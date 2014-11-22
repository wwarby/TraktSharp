using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	public class TraktCommentsLikeRequest : TraktBodylessPostByIdRequest<TraktComment> {

		public TraktCommentsLikeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments/{id}/like"; } }

	}

}
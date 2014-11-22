using System;
using System.Linq;

namespace TraktSharp.Request.Checkin {

	[Serializable]
	public class TraktCommentsDeleteRequest : TraktDeleteByIdRequest {

		public TraktCommentsDeleteRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments/{id}"; } }

	}

}
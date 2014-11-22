using System;
using System.Linq;

namespace TraktSharp.Request.Checkin {

	public class TraktCheckinDeleteRequest : TraktDeleteRequest {

		public TraktCheckinDeleteRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "checkin"; } }

	}

}
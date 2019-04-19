using System;
using System.Linq;

namespace TraktSharp.Request.Checkin {

	internal class TraktCheckinDeleteRequest : TraktDeleteRequest {

		internal TraktCheckinDeleteRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "checkin";

	}

}
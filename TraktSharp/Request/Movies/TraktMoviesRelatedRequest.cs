using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesRelatedRequest : TraktGetByIdRequest<IEnumerable<TraktMovie>> {

		public TraktMoviesRelatedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/related"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}
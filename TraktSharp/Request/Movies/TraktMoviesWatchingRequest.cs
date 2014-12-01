using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesWatchingRequest : TraktGetByIdRequest<IEnumerable<TraktUser>> {

		public TraktMoviesWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/watching"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}
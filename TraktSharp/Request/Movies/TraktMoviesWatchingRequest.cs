using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesWatchingRequest : TraktGetByIdRequest<IEnumerable<TraktUser>> {

		public TraktMoviesWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/watching"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

	}

}
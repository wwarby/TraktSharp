using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.Request {

	[Serializable]
	public abstract class TraktPostRequest<TResponse> : TraktRequest<TResponse> {

		protected TraktPostRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method {
			get { return HttpMethod.Post; }
		}

		protected override OAuthRequirementOptions OAuthRequirement {
			get { return OAuthRequirementOptions.Required; }
		}

		protected override bool SupportsPagination {
			get { return false; }
		}

	}

}
using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.Request {

	[Serializable]
	public abstract class TraktGetRequest<TResponse> : TraktRequest<TResponse> {

		protected TraktGetRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Get; } }

	}

}
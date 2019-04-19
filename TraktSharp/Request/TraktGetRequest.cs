using System.Net.Http;

namespace TraktSharp.Request {

	internal abstract class TraktGetRequest<TResponse> : TraktRequest<TResponse, object> {

		protected TraktGetRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method => HttpMethod.Get;

  }

}
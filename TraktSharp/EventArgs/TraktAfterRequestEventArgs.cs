using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.EventArgs {

	public class TraktAfterRequestEventArgs : System.EventArgs {

		public TraktAfterRequestEventArgs(HttpResponseMessage response, string responseText, HttpRequestMessage request, string requestBody, HttpClient client) {
			Response = response;
			ResponseText = responseText;
			Request = request;
			RequestBody = requestBody;
			Client = client;
		}

		public HttpRequestMessage Request { get; set; }

		public HttpResponseMessage Response { get; set; }

		public string ResponseText { get; set; }

		public string RequestBody { get; set; }

		public HttpClient Client { get; set; }

	}

}
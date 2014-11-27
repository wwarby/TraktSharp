using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.EventArgs {

	public class AfterRequestEventArgs : System.EventArgs {

		public AfterRequestEventArgs(HttpResponseMessage response, string responseText, HttpRequestMessage request, HttpClient client) {
			Response = response;
			ResponseText = responseText;
			Request = request;
			Client = client;
		}

		public HttpRequestMessage Request { get; set; }

		public HttpResponseMessage Response { get; set; }

		public string ResponseText { get; set; }

		public HttpClient Client { get; set; }

	}

}
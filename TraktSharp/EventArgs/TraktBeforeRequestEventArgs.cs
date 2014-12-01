using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.EventArgs {

	public class TraktBeforeRequestEventArgs : System.EventArgs {

		public TraktBeforeRequestEventArgs(HttpRequestMessage request, string requestBody, HttpClient client) {
			Request = request;
			RequestBody = requestBody;
			Client = client;
		}

		public HttpRequestMessage Request { get; set; }

		public string RequestBody { get; set; }

		public HttpClient Client { get; set; }

		public bool Cancel { get; set; }

	}

}
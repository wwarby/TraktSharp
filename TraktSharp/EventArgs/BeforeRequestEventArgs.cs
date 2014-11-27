using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.EventArgs {

	public class BeforeRequestEventArgs : System.EventArgs {

		public BeforeRequestEventArgs(HttpRequestMessage request, HttpClient client) {
			Request = request;
			Client = client;
		}

		public HttpRequestMessage Request { get; set; }

		public HttpClient Client { get; set; }

		public bool Cancel { get; set; }

	}

}
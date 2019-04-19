using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.EventArgs {

	/// <summary>Arguments for an event which executes immediately after an HTTP request is issued</summary>
	public class TraktBeforeRequestEventArgs : System.EventArgs {

		/// <summary>Default constructor for the event arguments</summary>
		/// <param name="request">The raw HTTP request</param>
		/// <param name="requestBody">The HTTP request body</param>
		/// <param name="client">The <see cref="HttpClient" /> used to execute the request</param>
		public TraktBeforeRequestEventArgs(HttpRequestMessage request, string requestBody, HttpClient client) {
			Request = request;
			RequestBody = requestBody;
			Client = client;
		}

		/// <summary>The raw HTTP request</summary>
		public HttpRequestMessage Request { get; set; }

		/// <summary>The HTTP request body</summary>
		public string RequestBody { get; set; }

		/// <summary>The <see cref="HttpClient" /> used to execute the request</summary>
		public HttpClient Client { get; set; }

		/// <summary>Set to <c>true</c> to prevent the request from being executed</summary>
		public bool Cancel { get; set; }

	}

}
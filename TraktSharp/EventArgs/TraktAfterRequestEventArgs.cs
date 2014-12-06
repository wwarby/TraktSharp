using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.EventArgs {

	/// <summary>Arguments for an event which executes immediately before an HTTP request is issued</summary>
	public class TraktAfterRequestEventArgs : System.EventArgs {

		/// <summary>Default constructor for the event arguments</summary>
		/// <param name="response">The raw HTTP response</param>
		/// <param name="responseText">The HTTP response body parsed as a string</param>
		/// <param name="request">The raw HTTP request</param>
		/// <param name="requestBody">The HTTP request body</param>
		/// <param name="client">The <see cref="HttpClient"/> used to execute the request</param>
		public TraktAfterRequestEventArgs(HttpResponseMessage response, string responseText, HttpRequestMessage request, string requestBody, HttpClient client) {
			Response = response;
			ResponseText = responseText;
			Request = request;
			RequestBody = requestBody;
			Client = client;
		}

		/// <summary>The raw HTTP response</summary>
		public HttpResponseMessage Response { get; set; }

		/// <summary>The HTTP response body parsed as a string</summary>
		public string ResponseText { get; set; }

		/// <summary>The raw HTTP request</summary>
		public HttpRequestMessage Request { get; set; }

		/// <summary>The HTTP request body</summary>
		public string RequestBody { get; set; }

		/// <summary>The <see cref="HttpClient"/> used to execute the request</summary>
		public HttpClient Client { get; set; }

	}

}
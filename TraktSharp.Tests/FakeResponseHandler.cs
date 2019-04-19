using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace TraktSharp.Tests {

	/// <summary>
	///     Fake HTTP message handler to generate HTTP response messages from local files rather than network calls for
	///     unit testing
	/// </summary>
	public class FakeResponseHandler : DelegatingHandler {

		private readonly Dictionary<string, HttpResponseMessage> _fakeResponses = new Dictionary<string, HttpResponseMessage>();

		private string _responseFilename = "";

		private string ResponseFilePath =>
			!string.IsNullOrEmpty(_responseFilename)
				? Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Response", _responseFilename)
				: string.Empty;

		internal void AddFakeResponse(string url, HttpStatusCode statusCode, string responseFilename) {
			_responseFilename = responseFilename;
			_fakeResponses[url] = new HttpResponseMessage(statusCode) {
				Content = new StringContent(string.IsNullOrEmpty(ResponseFilePath) ? string.Empty : File.ReadAllText(ResponseFilePath))
			};
		}

		/// <summary>Send the request</summary>
		/// <param name="request">The request</param>
		/// <param name="cancellationToken">The cancellation token</param>
		/// <returns>The response</returns>
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
			return await Task.Factory.StartNew(() => _fakeResponses.ContainsKey(request.RequestUri.AbsoluteUri)
					? _fakeResponses[request.RequestUri.AbsoluteUri]
					: new HttpResponseMessage(HttpStatusCode.NotFound) {
						RequestMessage = request,
						Content = new StringContent(string.Empty)
					},
				cancellationToken);
		}

	}

}
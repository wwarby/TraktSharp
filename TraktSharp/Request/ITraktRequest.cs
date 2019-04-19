using System;
using System.Linq;
using System.Threading.Tasks;

namespace TraktSharp.Request {

	/// <summary>A request to the Trakt API</summary>
	/// <typeparam name="TResponse">The expected response type from the request</typeparam>
	public interface ITraktRequest<TResponse> {

		/// <summary>Executes immediately before an HTTP request is issued</summary>
		event BeforeRequestEventHandler BeforeRequest;

		/// <summary>Executes immediately after an HTTP response is received</summary>
		event AfterRequestEventHandler AfterRequest;

		/// <summary>Execute the request asynchronously</summary>
		/// <returns>The response</returns>
		Task<TResponse> SendAsync();

	}

}
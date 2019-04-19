using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	/// <summary>An exception thrown when the Trakt API returns a <c>502: Bad Gateway</c> response status code</summary>
	/// <remarks>According to the docs this can't happen, but it does, and a CloudFlare error page is returned</remarks>
	[Serializable]
	[DataContract]
	public class TraktBadGatewayException : TraktException {

		/// <summary>Default constructor for the class</summary>
		/// <param name="traktError">The error response object returned by the Trakt API</param>
		/// <param name="requestUrl">The URL associated with the HTTP request that triggered the error</param>
		/// <param name="requestBody">The request body associated with the HTTP request that triggered the error</param>
		/// <param name="responseBody">The response body associated with the HTTP request that triggered the error</param>
		public TraktBadGatewayException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base((traktError != null) && !string.IsNullOrEmpty(traktError.Description) ? traktError.Description : "Bad Gateway - proxy error",
				HttpStatusCode.BadGateway,
				traktError,
				requestUrl,
				requestBody,
				responseBody) { }

	}

}
using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	/// <summary>An exception thrown when the Trakt API returns a <c>400: Bad Request</c> response status code</summary>
	[Serializable]
	[DataContract]
	public class TraktBadRequestException : TraktException {

		/// <summary>Default constructor for the class</summary>
		/// <param name="traktError">The error response object returned by the Trakt API</param>
		/// <param name="requestUrl">The URL associated with the HTTP request that triggered the error</param>
		/// <param name="requestBody">The request body associated with the HTTP request that triggered the error</param>
		/// <param name="responseBody">The response body associated with the HTTP request that triggered the error</param>
		public TraktBadRequestException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base("Bad Request - request couldn't be parsed", HttpStatusCode.BadRequest, traktError, requestUrl, requestBody, responseBody) { }

	}

}
using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	/// <summary>An exception thrown when the Trakt API returns a <c>409: Conflict</c> response status code</summary>
	[Serializable, DataContract]
	public class TraktConflictException : TraktException {

		/// <summary>Default constructor for the class</summary>
		/// <param name="traktError">The error response object returned by the Trakt API</param>
		/// <param name="requestUrl">The URL associated with the HTTP request that triggered the error</param>
		/// <param name="requestBody">The request body associated with the HTTP request that triggered the error</param>
		/// <param name="responseBody">The response body associated with the HTTP request that triggered the error</param>
		/// <param name="expiresAt">The date when the conflict that caused the error will expire</param>
		public TraktConflictException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null, DateTime? expiresAt = null)
			: base("Conflict - resource already created", HttpStatusCode.Conflict, traktError, requestUrl, requestBody, responseBody) { ExpiresAt = expiresAt; }

		/// <summary>The date when the conflict that caused the error will expire</summary>
		[DataMember]
		public DateTime? ExpiresAt { get; set; }

	}

}
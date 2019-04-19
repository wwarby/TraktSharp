﻿using System;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	/// <summary>An exception thrown when the Trakt API returns a <c>422: Unprocessable Entity</c> response status code</summary>
	[Serializable, DataContract]
	public class TraktUnprocessableEntityException : TraktException {

		/// <summary>Default constructor for the class</summary>
		/// <param name="traktError">The error response object returned by the Trakt API</param>
		/// <param name="requestUrl">The URL associated with the HTTP request that triggered the error</param>
		/// <param name="requestBody">The request body associated with the HTTP request that triggered the error</param>
		/// <param name="responseBody">The response body associated with the HTTP request that triggered the error</param>
		public TraktUnprocessableEntityException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base("Unprocessable Entity - validation errors", (HttpStatusCode)422, traktError, requestUrl, requestBody, responseBody) { }

	}

}
using System;
using System.Collections;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	/// <summary>A custom exception arising from a request to the Trakt API</summary>
	[Serializable, DataContract]
	public class TraktException : Exception {

		/// <summary>Default constructor for the class</summary>
		/// <param name="message">The custom error message reported by the Trakt API</param>
		/// <param name="statusCode">The HTTP response status code associated with the HTTP request that triggered the error</param>
		/// <param name="traktError">The error response object returned by the Trakt API</param>
		/// <param name="requestUrl">The URL associated with the HTTP request that triggered the error</param>
		/// <param name="requestBody">The request body associated with the HTTP request that triggered the error</param>
		/// <param name="responseBody">The response body associated with the HTTP request that triggered the error</param>
		public TraktException(string message, HttpStatusCode statusCode, TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base(message) {
			StatusCode = statusCode;
			TraktErrorType = traktError.Error;
			RequestUrl = requestUrl;
			RequestBody = requestBody;
			ResponseBody = responseBody;
		}

		/// <summary>The HTTP response status code associated with the HTTP request that triggered the error</summary>
		[DataMember]
		public HttpStatusCode StatusCode { get; set; }

		/// <summary>The error type reported by the Trakt API</summary>
		[DataMember]
		public string TraktErrorType { get; set; }

		/// <summary>The URL associated with the HTTP request that triggered the error</summary>
		[DataMember]
		public string RequestUrl { get; set; }

		/// <summary>The request body associated with the HTTP request that triggered the error</summary>
		[DataMember]
		public string RequestBody { get; set; }

		/// <summary>The response body associated with the HTTP request that triggered the error</summary>
		[DataMember]
		public string ResponseBody { get; set; }

		/// <summary>The custom error message reported by the Trakt API</summary>
		[DataMember]
		public override string Message => base.Message;

    /// <summary>The error source associated with the error</summary>
		[DataMember]
		public override string Source {
			get => base.Source;
			set => base.Source = value;
		}

		/// <summary>Data associated with the error</summary>
		[DataMember]
		public override IDictionary Data => base.Data;

    /// <summary>The stack trace associated with the error</summary>
		[DataMember]
		public override string StackTrace => base.StackTrace;

    /// <summary>A help link associated with the error</summary>
		[DataMember]
		public override string HelpLink {
			get => base.HelpLink;
			set => base.HelpLink = value;
		}

	}

}
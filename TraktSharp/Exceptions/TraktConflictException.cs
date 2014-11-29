using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	[Serializable, DataContract]
	public class TraktConflictException : TraktException {

		public TraktConflictException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null, DateTime? expiresAt = null)
			: base("Conflict - resource already created", HttpStatusCode.Conflict, traktError, requestUrl, requestBody, responseBody) { ExpiresAt = expiresAt; }

		[DataMember]
		public DateTime? ExpiresAt { get; set; }

	}

}
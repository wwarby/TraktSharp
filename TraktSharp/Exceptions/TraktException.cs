using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	[Serializable, DataContract]
	public class TraktException : Exception {

		[DataMember]
		public HttpStatusCode StatusCode { get; set; }

		[DataMember]
		public string TraktErrorType { get; set; }

		[DataMember]
		public string RequestUrl { get; set; }

		[DataMember]
		public string RequestBody { get; set; }

		[DataMember]
		public string ResponseBody { get; set; }

		[DataMember]
		public override string Message { get { return base.Message; } }

		[DataMember]
		public override string Source {
			get { return base.Source; } 
			set { base.Source = value; }
		}

		[DataMember]
		public override System.Collections.IDictionary Data { get { return base.Data; } }

		[DataMember]
		public override string StackTrace { get { return base.StackTrace; } }

		[DataMember]
		public override string HelpLink {
			get { return base.HelpLink; }
			set { base.HelpLink = value; }
		}

		public TraktException(string message, HttpStatusCode statusCode, TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base(message) {
			StatusCode = statusCode;
			TraktErrorType = traktError.Error;
			RequestUrl = requestUrl;
			RequestBody = requestBody;
			ResponseBody = responseBody;
		}

	}

}
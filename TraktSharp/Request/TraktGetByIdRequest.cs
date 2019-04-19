using System;
using System.Collections.Generic;

namespace TraktSharp.Request {

	internal abstract class TraktGetByIdRequest<TResponse> : TraktGetRequest<TResponse> {

		protected TraktGetByIdRequest(TraktClient client) : base(client) { }

		internal string Id { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			new Dictionary<string, string> {
				{"id", Id}
			};

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Id)) {
				throw new ArgumentException("Id not set.");
			}
		}

	}

}
using System;
using System.Collections.Generic;
using System.Linq;

namespace TraktSharp.Request {

	internal abstract class TraktPutByUsernameAndIdRequest<TResponse, TRequestBody> : TraktPutRequest<TResponse, TRequestBody> where TRequestBody : class {

		protected TraktPutByUsernameAndIdRequest(TraktClient client) : base(client) { }

		internal string Username { get; set; }

		internal string Id { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"username", Username},
				{"id", Id}
			};
		}

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(Username)) {
				throw new ArgumentException("Username not set.");
			}
			if (string.IsNullOrEmpty(Id)) {
				throw new ArgumentException("Id not set.");
			}
		}

	}

}
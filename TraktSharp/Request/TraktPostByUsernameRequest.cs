using System;
using System.Collections.Generic;
using System.Linq;

namespace TraktSharp.Request {

	public abstract class TraktPostByUsernameRequest<TResponse, TRequestBody> : TraktPostRequest<TResponse, TRequestBody> where TRequestBody : class {

		protected TraktPostByUsernameRequest(TraktClient client) : base(client) { }

		public string Username { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"username", Username}
			};
		}

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(Username)) {
				throw new ArgumentException("Username not set.");
			}
		}

	}

}
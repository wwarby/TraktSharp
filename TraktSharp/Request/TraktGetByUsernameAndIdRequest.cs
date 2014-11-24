using System;
using System.Collections.Generic;
using System.Linq;

namespace TraktSharp.Request {

	public abstract class TraktGetByUsernameAndIdRequest<TResponse> : TraktGetRequest<TResponse> {

		protected TraktGetByUsernameAndIdRequest(TraktClient client) : base(client) { }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Optional; } }

		public string Username { get; set; }

		public string Id { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"username", Username},
				{"id", Id}
			};
		}

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Username)) {
				throw new ArgumentException("Username not set.");
			}
			if (string.IsNullOrEmpty(Id)) {
				throw new ArgumentException("Id not set.");
			}
		}

	}

}
using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Enums;

namespace TraktSharp.Request {

	public abstract class TraktGetByUsernameRequest<TResponse> : TraktGetRequest<TResponse> {

		protected TraktGetByUsernameRequest(TraktClient client) : base(client) { }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Optional; } }

		public string Username { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"username", Username}
			};
		}

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Username)) {
				throw new ArgumentException("Username not set.");
			}
		}

	}

}
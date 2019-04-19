using System;
using System.Collections.Generic;
using TraktSharp.Enums;

namespace TraktSharp.Request {

	internal abstract class TraktGetByUsernameRequest<TResponse> : TraktGetRequest<TResponse> {

		protected TraktGetByUsernameRequest(TraktClient client) : base(client) { }

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

    internal string Username { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			new Dictionary<string, string> {
				{"username", Username}
			};

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Username)) {
				throw new ArgumentException("Username not set.");
			}
		}

	}

}
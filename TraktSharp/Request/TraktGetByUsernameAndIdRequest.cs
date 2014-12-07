using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Enums;

namespace TraktSharp.Request {

	internal abstract class TraktGetByUsernameAndIdRequest<TResponse> : TraktGetRequest<TResponse> {

		protected TraktGetByUsernameAndIdRequest(TraktClient client) : base(client) { }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Optional; } }

		internal string Username { get; set; }

		internal string Id { get; set; }

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
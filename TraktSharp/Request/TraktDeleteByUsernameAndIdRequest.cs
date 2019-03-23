using System;
using System.Collections.Generic;
using System.Linq;

namespace TraktSharp.Request {

	internal abstract class TraktDeleteByUsernameAndIdRequest : TraktDeleteRequest {

		protected TraktDeleteByUsernameAndIdRequest(TraktClient client) : base(client) { }

		internal string Username { get; set; }

		internal string Id { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			new Dictionary<string, string> {
				{"username", Username},
				{"id", Id}
			};

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
﻿using System;
using System.Collections.Generic;

namespace TraktSharp.Request {

	internal abstract class TraktBodylessPostByUsernameRequest<TResponse> : TraktBodylessPostRequest<TResponse> {

		protected TraktBodylessPostByUsernameRequest(TraktClient client) : base(client) { }

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
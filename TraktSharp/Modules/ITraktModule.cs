using System;
using System.Linq;
using TraktSharp.Request;

namespace TraktSharp.Modules {

	/// <summary>Represents a module containing Trakt API request methods</summary>
	internal interface ITraktModule {
		
		/// <summary>Executes immediately before an HTTP request is issued</summary>
		event BeforeRequestEventHandler BeforeRequest;

		/// <summary>Executes immediately after an HTTP response is received</summary>
		event AfterRequestEventHandler AfterRequest;

	}

}
using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Request;

namespace TraktSharp.Modules {

	/// <summary>Base class for module containing Trakt API request methods</summary>
	public abstract class TraktModuleBase : ITraktModule {

		/// <summary>Executes immediately before an HTTP request is issued</summary>
		public event BeforeRequestEventHandler BeforeRequest;

		/// <summary>Executes immediately after an HTTP response is received</summary>
		public event AfterRequestEventHandler AfterRequest;

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		protected TraktModuleBase(TraktClient client) { Client = client; }

		/// <summary>The owning instance of <see cref="TraktClient"/></summary>
		public TraktClient Client { get; private set; }

		/// <summary>Send the HTTP request</summary>
		/// <typeparam name="T">The return type for the request</typeparam>
		/// <param name="request">The request</param>
		/// <returns>An instance of <typeparamref name="T"/> containing the payload from the Trakt API</returns>
		protected async Task<T> SendAsync<T>(ITraktRequest<T> request) {
			if (BeforeRequest != null) { request.BeforeRequest += (sender, e) => BeforeRequest(sender, e); }
			if (AfterRequest != null) { request.AfterRequest += (sender, e) => AfterRequest(sender, e); }
			var ret = await request.SendAsync();
			return ret;
		}

	}

}
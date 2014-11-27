using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Request;

namespace TraktSharp.Modules {

	public interface ITraktModule {
		event BeforeRequestEventHandler BeforeRequest;
		event AfterRequestEventHandler AfterRequest;
	}

	public class TraktModuleBase : ITraktModule {

		public event BeforeRequestEventHandler BeforeRequest;
		public event AfterRequestEventHandler AfterRequest;

		protected TraktModuleBase(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		protected async Task<T> SendAsync<T>(ITraktRequest<T> request) {
			if (BeforeRequest != null) { request.BeforeRequest += (sender, e) => BeforeRequest(sender, e); }
			if (AfterRequest != null) { request.AfterRequest += (sender, e) => AfterRequest(sender, e); }
			var ret = await request.SendAsync();
			return ret;
		}

	}

}
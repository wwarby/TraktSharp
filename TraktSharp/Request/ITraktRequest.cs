using System;
using System.Linq;
using System.Threading.Tasks;

namespace TraktSharp.Request {

	public interface ITraktRequest<TResponse> {

		event BeforeRequestEventHandler BeforeRequest;
		event AfterRequestEventHandler AfterRequest;
		Task<TResponse> SendAsync();

	}

}
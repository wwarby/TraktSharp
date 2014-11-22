using System;
using System.Linq;

namespace TraktSharp.Modules {

	public class TraktScrobbleModule {

		public TraktScrobbleModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }



	}

}
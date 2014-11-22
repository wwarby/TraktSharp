using System;
using System.Linq;

namespace TraktSharp.Modules {

	public class TraktSyncModule {

		public TraktSyncModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }



	}

}
using System;
using System.Linq;

namespace TraktSharp.Modules {

	public class TraktUsersModule {

		public TraktUsersModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }



	}

}
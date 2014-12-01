using System;
using System.Linq;
using TraktSharp.EventArgs;

namespace TraktSharp.Request {

	public delegate void AfterRequestEventHandler(object sender, TraktAfterRequestEventArgs e);

}
using System;
using System.Linq;
using TraktSharp.EventArgs;

namespace TraktSharp.Request {

	/// <summary>Delegate for an event which executes immediately before an HTTP request is issued</summary>
	/// <param name="sender">The sender</param>
	/// <param name="e">The event arguments</param>
	public delegate void BeforeRequestEventHandler(object sender, TraktBeforeRequestEventArgs e);

}
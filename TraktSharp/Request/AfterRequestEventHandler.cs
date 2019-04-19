using System;
using System.Linq;
using TraktSharp.EventArgs;

namespace TraktSharp.Request {

	/// <summary>Delegate for an event which executes immediately after an HTTP request is issued</summary>
	/// <param name="sender">The sender</param>
	/// <param name="e">The event arguments</param>
	public delegate void AfterRequestEventHandler(object sender, TraktAfterRequestEventArgs e);

}
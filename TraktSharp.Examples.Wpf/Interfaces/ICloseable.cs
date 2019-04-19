using System;

namespace TraktSharp.Examples.Wpf.Interfaces {

	internal interface ICloseable {

		event EventHandler<System.EventArgs> RequestClose;

	}

}
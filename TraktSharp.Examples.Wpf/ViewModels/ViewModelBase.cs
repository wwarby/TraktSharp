using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TraktSharp.Examples.Wpf.ViewModels {

	internal abstract class ViewModelBase : INotifyPropertyChanged {

		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
			if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
		}

	}

}